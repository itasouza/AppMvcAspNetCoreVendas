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
    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository, IMapper mapper,
                                      IEnderecoRepository enderecoRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        [Route("Fornecedores/lista-de-fornecedores")]
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
                    consulta = await _mapper.Map<IEnumerable<FornecedorViewModel>>(
                                                 await _fornecedorRepository.Buscar(p => p.Nome.Contains(TextoPesquisa)))
                                                .ToPagedListAsync(pagina, tamanhoPagina);
                }

                if (TextoPesquisa != null && valorSelecao == 2)
                {
                    consulta = await _mapper.Map<IEnumerable<FornecedorViewModel>>(
                                                 await _fornecedorRepository.Buscar(p => p.Documento.Contains(TextoPesquisa)))
                                                .ToPagedListAsync(pagina, tamanhoPagina);
                }

                if (valorSelecao == 3 && DataInicial != null && DataFinal != null)
                {
                    consulta = await _mapper.Map<IEnumerable<FornecedorViewModel>>(
                             await _fornecedorRepository.Buscar(p => p.DataCadastro >= dataInicio && p.DataCadastro <= dataFinal))
                            .ToPagedListAsync(pagina, tamanhoPagina);
                }

            }
            else
            {
                if (sortOrder == null)
                {
                    consulta = await _mapper.Map<IEnumerable<FornecedorViewModel>>(
                               await _fornecedorRepository.ObterTodos())
                               .ToPagedListAsync(pagina, tamanhoPagina);
                }
                else
                {
                    consulta = await _mapper.Map<IEnumerable<FornecedorViewModel>>(
                               await _fornecedorRepository.ObterTodosFornecedorProdutosEnderecoOrdenado(sortOrder))
                               .ToPagedListAsync(pagina, tamanhoPagina);
                }

            }

            ViewBag.TamanhoPagina = tamanhoPagina;
            return View(consulta);
        }


        [Route("Fornecedores/criar-novo-fornecedor")]
        public IActionResult Create()
        {
            HttpContext.Session.SetString("IdFornecedorGerado","0");            
            return View();
        }



        [Route("Fornecedores/criar-novo-fornecedor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {

            if (!ModelState.IsValid) return View(fornecedorViewModel);
            string cadastro = HttpContext.Session.GetString("IdFornecedorGerado"); 
            var IdFornecedorGerado = new Guid();

            try
            {
                if(cadastro == "0")
                {
                    var dados = _mapper.Map<Fornecedor>(fornecedorViewModel);
                    await _fornecedorRepository.Adicionar(dados);
                    IdFornecedorGerado = dados.Id;
                    HttpContext.Session.SetString("IdFornecedorGerado", IdFornecedorGerado.ToString());
                }
                else
                {
                    IdFornecedorGerado =  Guid.Parse(HttpContext.Session.GetString("IdFornecedorGerado"));
                }

                fornecedorViewModel = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(IdFornecedorGerado));
                TempData["msg"] = "O Cadastro foi realizado com sucesso";
            }
            catch (Exception ex)
            {
                TempData["Erro"] = "Não foi possivel gravar o registro." + ex.Message;
                return RedirectToAction(nameof(Create));
                throw;
            }

            return View(fornecedorViewModel); ;

        }
      

        [Route("Fornecedores/editar-fornecedor/{id:Guid}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var fornecedorViewModel = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }
            return View(fornecedorViewModel);
        }



        [Route("Fornecedores/editar-fornecedor/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(fornecedorViewModel);


            try
            {
                var dados = _mapper.Map<Fornecedor>(fornecedorViewModel);
                await _fornecedorRepository.Atualizar(dados);
                TempData["msg"] = "O Cadastro foi atualizado com sucesso";
            }
            catch (Exception ex)
            {

                TempData["Erro"] = "Não foi possivel atualizar o registro." + ex.Message;
                return RedirectToAction(nameof(Index));
                throw;
            }

            return View(fornecedorViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            bool Excluir = true;
            string MensagemTipo = "";
            string MensagemTexto = "";

            var fornecedorViewModel = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);
            if (fornecedorViewModel == null) return NotFound();

            try
            {
                //se tiver endereço, avisa que não pode excluir o fornecedor
                if (fornecedorViewModel.Enderecos != null && Excluir == true)
                {
                    MensagemTipo = "error";
                    MensagemTexto = "Não foi possivel excluir porque o fornecedor possui endereço cadastrado.";
                    Excluir = false;
                }

                if (fornecedorViewModel.Produtos != null && Excluir == true)
                {
                    MensagemTipo = "error";
                    MensagemTexto = "Não foi possivel excluir porque o fornecedor possui produtos cadastrado.";
                    Excluir = false;
                }

                if (Excluir)
                {
                    //remover o fornecedor
                    await _fornecedorRepository.Remover(id);
                    TempData["msg"] = fornecedorViewModel.Nome + " foi excluido com sucesso.";
                    MensagemTipo = "success";
                    MensagemTexto = fornecedorViewModel.Nome + " foi excluido com sucesso.";
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
        public async Task<IActionResult> AtualizarEndereco(Guid Id, FornecedorViewModel fornecedorViewModel)
        {
            string MensagemTipo = "";
            string MensagemTexto = "";

            try
            {

                if (fornecedorViewModel.Endereco == null) return NotFound();

                if (fornecedorViewModel.Endereco.Complemento == null)
                    fornecedorViewModel.Endereco.Complemento = "Sem Complemento";

                fornecedorViewModel.Endereco.FornecedorId = Id;
                var dados = _mapper.Map<Endereco>(fornecedorViewModel.Endereco);
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
        public async Task<IActionResult> AdicionarEndereco(Guid Id, FornecedorViewModel fornecedorViewModel)
        {
            string MensagemTipo = "";
            string MensagemTexto = "";

            try
            {
                if (fornecedorViewModel.Endereco == null) return NotFound();


                if (fornecedorViewModel.Endereco.Complemento == null)
                    fornecedorViewModel.Endereco.Complemento = "Sem Complemento";

                fornecedorViewModel.Endereco.FornecedorId = Id;

                var dados = _mapper.Map<Endereco>(fornecedorViewModel.Endereco);
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

            var registros = await _mapper.Map<IEnumerable<FornecedorViewModel>>(
                                     await _fornecedorRepository.ObterTodos()).ToListAsync();

            StringBuilder arquivo = new StringBuilder();
            arquivo.AppendLine("Id;Nome;Documento;Ativo;Tipo de Fornecedor");

            foreach (var item in registros)
            {
                arquivo.AppendLine(item.Id + ";" + item.Nome + ";" + item.Documento.ToString() + ";" + item.Ativo + ";" + item.TipoFornecedor);
            }

            return File(Encoding.ASCII.GetBytes(arquivo.ToString()), "text/csv", "Fornecedor.csv");
        }


        public async Task<IActionResult> VisualizarArquivoPDF()
        {
            var registros = await _mapper.Map<IEnumerable<FornecedorViewModel>>(
                         await _fornecedorRepository.ObterTodos()).ToListAsync();


            var relatorioPDF = new ViewAsPdf
            {
                ViewName = "VisualizarPDF",
                IsGrayScale = false,
                FileName = "Fornecedor.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                Model = registros
            };

            return relatorioPDF;
        }


        public async Task<IActionResult> VisualizarHTML()
        {
            var registros = await _mapper.Map<IEnumerable<FornecedorViewModel>>(
                         await _fornecedorRepository.ObterTodos()).ToListAsync();

            return View(registros);
        }





    }
}
