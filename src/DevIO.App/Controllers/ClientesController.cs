using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using X.PagedList;

namespace DevIO.App.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;


        public ClientesController(IClienteRepository clienteRepository, IMapper mapper,
                              IEnderecoRepository enderecoRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }


        [Route("Clientes/lista-de-clientes")]
        public async Task<IActionResult> Index(string sortOrder, string TextoPesquisa = null,
                                                   int valorSelecao = 0,
                                                   string DataInicial = null,
                                                   string DataFinal = null,
                                                   int pagina = 1,
                                                   int tamanhoPagina = 10)
        {
            //retorna o que foi selecionado
            DateTime? dataInicio = null;
            DateTime? dataFinal = null;
            var consulta = new object();



            if (TextoPesquisa != null)
            {
                ViewBag.TextoPesquisa = TextoPesquisa;
                ViewBag.show = "show";
            }

            if (valorSelecao >= 0)
                ViewBag.valorSelecao = valorSelecao;

            if (DataInicial != null)
            {
                ViewBag.DataInicial = DataInicial;
                dataInicio = Convert.ToDateTime(DataInicial).AddHours(0).AddMinutes(00).AddSeconds(00);
            }
            if (DataFinal != null)
            {
                ViewBag.DataFinal = DataFinal;
                dataFinal = Convert.ToDateTime(DataFinal).AddHours(23).AddMinutes(59).AddSeconds(59);
            }

            if (valorSelecao > 0)
            {
                if (TextoPesquisa != null && valorSelecao == 1)
                {
                    consulta = await _mapper.Map<IEnumerable<ClienteViewModel>>(
                                                 await _clienteRepository.Buscar(p => p.Nome.Contains(TextoPesquisa)))
                                                .ToPagedListAsync(pagina, tamanhoPagina);
                }

                if (TextoPesquisa != null && valorSelecao == 2)
                {
                    consulta = await _mapper.Map<IEnumerable<ClienteViewModel>>(
                                                 await _clienteRepository.Buscar(p => p.Documento.Contains(TextoPesquisa)))
                                                .ToPagedListAsync(pagina, tamanhoPagina);
                }

                if (valorSelecao == 3 && DataInicial != null && DataFinal != null)
                {
                    consulta = await _mapper.Map<IEnumerable<ClienteViewModel>>(
                             await _clienteRepository.Buscar(p => p.DataCadastro >= dataInicio && p.DataCadastro <= dataFinal))
                            .ToPagedListAsync(pagina, tamanhoPagina);
                }

            }
            else
            {
                if (sortOrder == null)
                {
                    consulta = await _mapper.Map<IEnumerable<ClienteViewModel>>(
                               await _clienteRepository.ObterTodos())
                               .ToPagedListAsync(pagina, tamanhoPagina);
                }
                else
                {
                    consulta = await _mapper.Map<IEnumerable<ClienteViewModel>>(
                               await _clienteRepository.ObterTodosClienteEnderecoOrdenado(sortOrder))
                               .ToPagedListAsync(pagina, tamanhoPagina);
                }

            }

            ViewBag.TamanhoPagina = tamanhoPagina;
            return View(consulta);
        }


        [Route("Clientes/criar-novo-cliente")]
        public IActionResult Create()
        {
            HttpContext.Session.SetString("IdClienteGerado", "0");
            return View();
        }


        [Route("Clientes/criar-novo-cliente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {

            if (!ModelState.IsValid) return View(clienteViewModel);
            string cadastro = HttpContext.Session.GetString("IdClienteGerado");
            var IdClienteGerado = new Guid();

            try
            {
                if (cadastro == "0")
                {
                    var dados = _mapper.Map<Cliente>(clienteViewModel);
                    await _clienteRepository.Adicionar(dados);
                    IdClienteGerado = dados.Id;
                    HttpContext.Session.SetString("IdClienteGerado", IdClienteGerado.ToString());
                }
                else
                {
                    IdClienteGerado = Guid.Parse(HttpContext.Session.GetString("IdClienteGerado"));
                }

                clienteViewModel = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClienteEndereco(IdClienteGerado));
                TempData["msg"] = "O Cadastro foi realizado com sucesso";
            }
            catch (Exception ex)
            {
                TempData["Erro"] = "Não foi possivel gravar o registro." + ex.Message;
                return RedirectToAction(nameof(Create));
                throw;
            }

            return View(clienteViewModel); ;

        }


        [Route("Clientes/editar-cliente/{id:Guid}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        { 
            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClienteEndereco(id));

            if (clienteViewModel == null)
            {
                return NotFound();
            }
            return View(clienteViewModel);
        }



        [Route("Clientes/editar-cliente/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(clienteViewModel);


            try
            {
                var dados = _mapper.Map<Cliente>(clienteViewModel);
                await _clienteRepository.Atualizar(dados);
                TempData["msg"] = "O Cadastro foi atualizado com sucesso";
            }
            catch (Exception ex)
            {

                TempData["Erro"] = "Não foi possivel atualizar o registro." + ex.Message;
                return RedirectToAction(nameof(Index));
                throw;
            }

            return View(clienteViewModel);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            bool Excluir = true;
            string MensagemTipo = "";
            string MensagemTexto = "";

            var clienteViewModel = await _clienteRepository.ObterClienteEndereco(id);
            if (clienteViewModel == null) return NotFound();

            try
            {
                //se tiver endereço, avisa que não pode excluir o cliente
                if (clienteViewModel.Enderecos != null && Excluir == true)
                {
                    MensagemTipo = "error";
                    MensagemTexto = "Não foi possivel excluir porque o fornecedor possui endereço cadastrado.";
                    Excluir = false;
                }


                if (Excluir)
                {
                    //remover o cliente
                    await _clienteRepository.Remover(id);
                    TempData["msg"] = clienteViewModel.Nome + " foi excluido com sucesso.";
                    MensagemTipo = "success";
                    MensagemTexto = clienteViewModel.Nome + " foi excluido com sucesso.";
                }

            }
            catch (Exception)
            {
                MensagemTipo = "error";
                MensagemTexto = "Houve um erro, não foi possivel excluir o fornecedor";
            }
            return Json(new
            {
                result = MensagemTipo,
                mensaje = MensagemTexto
            });
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarEndereco(Guid Id, ClienteViewModel clienteViewModel)
        {
            string MensagemTipo = "";
            string MensagemTexto = "";

            try
            {

                if (clienteViewModel.Endereco == null) return NotFound();

                if (clienteViewModel.Endereco.Complemento == null)
                    clienteViewModel.Endereco.Complemento = "Sem Complemento";

                clienteViewModel.Endereco.ClienteId = Id;
                var dados = _mapper.Map<Endereco>(clienteViewModel.Endereco);
                await _enderecoRepository.Atualizar(dados);
                MensagemTipo = "success";
                MensagemTexto = "O Cadastro foi atualizado com sucesso";
            }
            catch (Exception)
            {
                MensagemTipo = "error";
                MensagemTexto = "Não foi possivel atualizar o registro.";
            }

            return Json(new
            {
                result = MensagemTipo,
                mensaje = MensagemTexto
            });
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarEndereco(Guid Id, ClienteViewModel clienteViewModel)
        {
            string MensagemTipo = "";
            string MensagemTexto = "";

            try
            {
                if (clienteViewModel.Endereco == null) return NotFound();


                if (clienteViewModel.Endereco.Complemento == null)
                    clienteViewModel.Endereco.Complemento = "Sem Complemento";

                clienteViewModel.Endereco.ClienteId = Id;

                var dados = _mapper.Map<Endereco>(clienteViewModel.Endereco);
                await _enderecoRepository.Adicionar(dados);
                MensagemTipo = "success";
                MensagemTexto = "O Cadastro foi adicionado com sucesso";
            }
            catch (Exception)
            {

                MensagemTipo = "error";
                MensagemTexto = "Não foi possivel adicionar o registro.";
            }

            return Json(new
            {
                result = MensagemTipo,
                mensaje = MensagemTexto
            });
        }



        [HttpPost, ActionName("DeleteEndereco")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirEndereco(Guid id)
        {
            string MensagemTipo = "";
            string MensagemTexto = "";

            var enderecoViewModel = await _enderecoRepository.ObterEnderecoPorID(id);
            if (enderecoViewModel == null)
            {
                return NotFound();
            }

            try
            {
                await _enderecoRepository.Remover(id);
                MensagemTipo = "success";
                MensagemTexto = enderecoViewModel.Logradouro + " foi excluido com sucesso.";
            }
            catch (Exception)
            {
                MensagemTipo = "error";
                MensagemTexto = "Não foi possivel remover o registro ";
            }
            return Json(new
            {
                result = MensagemTipo,
                mensaje = MensagemTexto
            });
        }


        public async Task<IActionResult> VisualizarCSV()
        {

            var registros = await _mapper.Map<IEnumerable<ClienteViewModel>>(
                                     await _clienteRepository.ObterTodos()).ToListAsync();

            StringBuilder arquivo = new StringBuilder();
            arquivo.AppendLine("Id;Nome;Documento;Ativo;Tipo de Cliente");

            foreach (var item in registros)
            {
                arquivo.AppendLine(item.Id + ";" + item.Nome + ";" + item.Documento.ToString() + ";" + item.Ativo + ";" + item.TipoCliente);
            }

            return File(Encoding.ASCII.GetBytes(arquivo.ToString()), "text/csv", "Fornecedor.csv");
        }


        public async Task<IActionResult> VisualizarArquivoPDF()
        {
            var registros = await _mapper.Map<IEnumerable<ClienteViewModel>>(
                                     await _clienteRepository.ObterTodos()).ToListAsync();


            var relatorioPDF = new ViewAsPdf
            {
                ViewName = "VisualizarPDF",
                IsGrayScale = false,
                FileName = "cliente.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                Model = registros
            };

            return relatorioPDF;
        }


        public async Task<IActionResult> VisualizarHTML()
        {
            var registros = await _mapper.Map<IEnumerable<ClienteViewModel>>(
                                     await _clienteRepository.ObterTodos()).ToListAsync();

            return View(registros);
        }



    }
}