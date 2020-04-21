using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
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
    public class ProdutosController : BaseController
    {
        //TODO - adicionar combo-dependente no produto http://www.graciomar.com.br/blog/40/exemplo-combo-dependente-com-jquery

        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
                                  IFornecedorRepository fornecedorRepository,
                                  IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }


        [Route("Produtos/lista-de-produtos")]
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
                    consulta = await _mapper.Map<IEnumerable<ProdutoViewModel>>(
                                                await _produtoRepository.BuscarProdutosFornecedores(p => p.Nome.Contains(TextoPesquisa)))
                                               .ToPagedListAsync(pagina, tamanhoPagina);
                    ViewBag.TamanhoPagina = tamanhoPagina;
                    return View(consulta);
                }

                if (TextoPesquisa != null && valorSelecao == 2)
                {
                    consulta = await _mapper.Map<IEnumerable<ProdutoViewModel>>(
                            await _produtoRepository.BuscarProdutosFornecedores(p => p.Fornecedor.Nome.Contains(TextoPesquisa)))
                           .ToPagedListAsync(pagina, tamanhoPagina);

                    ViewBag.TamanhoPagina = tamanhoPagina;
                    return View(consulta);
                }

                if (valorSelecao == 3)
                {
                    Expression<Func<Produto, bool>> filtro = null;

                    if (dataInicio.HasValue && dataFinal.HasValue)
                        filtro = p => p.DataCadastro >= dataInicio && p.DataCadastro <= dataFinal;


                    consulta = await _mapper.Map<IEnumerable<ProdutoViewModel>>(
                                await _produtoRepository.BuscarProdutosFornecedores(filtro))
                               .ToPagedListAsync(pagina, tamanhoPagina);

                    ViewBag.TamanhoPagina = tamanhoPagina;
                    return View(consulta);
                }
            }
            else
            {
                if (sortOrder == null)
                {
                    consulta = await _mapper.Map<IEnumerable<ProdutoViewModel>>(
                               await _produtoRepository.ObterProdutosFornecedores())
                              .ToPagedListAsync(pagina, tamanhoPagina);
                }
                else
                {
                    consulta = await _mapper.Map<IEnumerable<ProdutoViewModel>>(
                               await _produtoRepository.ObterTodosProdutosFornecedoresOrdenado(sortOrder))
                              .ToPagedListAsync(pagina, tamanhoPagina);
                }
            }


            ViewBag.TamanhoPagina = tamanhoPagina;
            return View(consulta);

        }

        [Route("Produtos/criar-novo-produto")]
        public IActionResult Create()
        {
            return View();
        }



        [Route("Produtos/criar-novo-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {

            if (!ModelState.IsValid) return View(produtoViewModel);

            try
            {
                if (produtoViewModel.ImagemUpload != null)
                {
                    var imgPrefixo = Guid.NewGuid() + "_";
                    if (!await UpLoadArquivo(produtoViewModel.ImagemUpload, imgPrefixo))
                    {
                        return View(produtoViewModel);
                    }
                    produtoViewModel.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;
                }
                TempData["msg"] = "O Cadastro foi realizado com sucesso";
                await _produtoRepository.Adicionar(_mapper.Map<Produto>(produtoViewModel));
            }
            catch (Exception ex)
            {
                TempData["Erro"] = "Não foi possivel gravar o registro." + ex.Message;
                return RedirectToAction(nameof(Index));
                throw;
            }

            return RedirectToAction(nameof(Index));
        }


        [Route("Produtos/editar-produto/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }
            return View(produtoViewModel);
        }


    
        [Route("Produtos/editar-produto/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {

            //fornecedor selecionado
            var fornecedorSelecioando = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(produtoViewModel.FornecedorId));
            produtoViewModel.Fornecedor = fornecedorSelecioando;

            if (id != produtoViewModel.Id) return NotFound();
            //  if (!ModelState.IsValid) return View(produtoViewModel);

            //se tiver imagem nova, vou sobrescrever
            var imgPrefixo = Guid.NewGuid() + "_";
            if (produtoViewModel.ImagemUpload != null)
            {
                if (!await UpLoadArquivo(produtoViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(produtoViewModel);
                }
                produtoViewModel.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;
            }

            try
            {
                var dados = _mapper.Map<Produto>(produtoViewModel);
                await _produtoRepository.Atualizar(dados);
                TempData["msg"] = "O Cadastro foi atualizado com sucesso";
            }
            catch (Exception ex)
            {

                TempData["Erro"] = "Não foi possivel atualizar o registro." + ex.Message;
                return RedirectToAction(nameof(Index));
                throw;
            }

            return RedirectToAction(nameof(Index));

        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            string MensagemTipo = "";
            string MensagemTexto = "";

            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            try
            {
                await _produtoRepository.Remover(id);
                TempData["msg"] = produtoViewModel.Nome + " foi excluido com sucesso.";
                MensagemTipo = "success";
                MensagemTexto = produtoViewModel.Nome + " foi excluido com sucesso.";
            }
            catch (Exception ex)
            {

                TempData["Erro"] = "Não foi possivel remover o registro." + ex.Message;
                MensagemTipo = "error";
                MensagemTexto = "Não foi possivel remover o registro ";
                return RedirectToAction(nameof(Index));
                throw;
            }
            return Json(new
            {
                result = MensagemTipo,
                mensaje = MensagemTexto
            });
        }


        [HttpGet]
        public async Task<IActionResult> ObterFornecedorParaAutocompleteTexto(string text)
        {

            if (string.IsNullOrEmpty(text))
            {
                return Json(new
                {
                    result = ""
                }); ;
            }
            else
            {
                var dados = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterFornecedorParaAutocompleteTexto(text));

                return Json(new
                {
                    results = dados
                });

            }

        }

        [HttpGet]
        public async Task<IActionResult> ObterFornecedorParaAutocompleteId(Guid id)
        {
            var dados = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorParaAutocompleteId(id));

            return Json(new
            {
                results = dados
            });

        }

        public async Task<IActionResult> VisualizarCSV()
        {

            var registros = await _mapper.Map<IEnumerable<ProdutoViewModel>>(
                            await _produtoRepository.ObterTodos()).ToListAsync();
            StringBuilder arquivo = new StringBuilder();
            arquivo.AppendLine("Id do Produto;Nome do Produto;Descricao Produto;Ativo;Imagem do produto ");

            foreach (var item in registros)
            {
                arquivo.AppendLine(item.Id + ";" + item.Nome + ";" + item.Descricao + ";" + item.Ativo + ";" + item.Imagem);
            }

            return File(Encoding.ASCII.GetBytes(arquivo.ToString()), "text/csv", "dadosproduto.csv");
        }

        public async Task<IActionResult> VisualizarArquivoPDF()
        {
            var registros = await _mapper.Map<IEnumerable<ProdutoViewModel>>(
                         await _produtoRepository.ObterTodos()).ToListAsync();
          

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

        public async Task<IActionResult> VisualizarPDF()
        {
            var registros = await _mapper.Map<IEnumerable<ProdutoViewModel>>(
                         await _produtoRepository.ObterTodos()).ToListAsync();

            return View(registros);
        }


        public async Task<IActionResult> VisualizarHTML()
        {
            var registros = await _mapper.Map<IEnumerable<ProdutoViewModel>>(
                         await _produtoRepository.ObterTodos()).ToListAsync();

            return View(registros);
        }



        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));
            produto.Fornecedor = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedor(produto.FornecedorId));
            return produto;
        }



        private async Task<bool> UpLoadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImagensPerfil", imgPrefixo + arquivo.FileName);
            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }
            return true;
        }


    }
}
