using LojaAPI.DAO;
using LojaAPI.Models;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System;
using System.Collections.Generic;

namespace LojaAPI.Controllers { 

    public class CarrinhoController : ApiController {

        //  Por padrão a API já me retorna JSON
        public HttpResponseMessage Get(int id) {
            try {
                CarrinhoDAO dao = new CarrinhoDAO();
                Carrinho carrinho = dao.busca(id);
                return Request.CreateResponse(HttpStatusCode.OK, carrinho);
            } catch(KeyNotFoundException) {
                string message = string.Format("O carrinho {0} não foi encontrado.", id);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        //  Insere no meu banco de dados passando um JSON ou XML no corpo
        public HttpResponseMessage Post([FromBody] Carrinho carrinho) {
            //  Acesso ao banco de dados
            CarrinhoDAO dao = new CarrinhoDAO();
            dao.adiciona(carrinho);

            //  Retorna a mensagem do servidor
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

            //  Onde está a localização do recurso que a gente acabou de criar
            //  1º parâmetro - Nome da minha rota
            //  2º parâmetro - O que eu quero passar pra essa rota pra ser gerado para mim
            string location = Url.Link("DefaultApi", new { controller = "carrinho", id = carrinho.Id});

            //  Adiciona a localização do meu recurso no meu cabeçalho
            response.Headers.Location = new Uri(location);
            
            return response;
        }

        //  Diz que os meus ids vem do meu URI (endpoint ou da url)
        //  Rota customizada
        [Route("api/carrinho/{carrinho_id}/produto/{produto_id}")]
        public HttpResponseMessage Delete([FromUri] int carrinho_id, [FromUri] int produto_id) {
            CarrinhoDAO dao = new CarrinhoDAO();
            Carrinho carrinho = dao.busca(carrinho_id);
            carrinho.remove(produto_id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //  Eu recebo um Produto no corpo da minha requisição
        [Route("api/carrinho/{carrinho_id}/produto/{produto_id}")]
        public HttpResponseMessage Put([FromBody] Produto produto, [FromUri] int carrinho_id, [FromUri] int produto_id) {
            var dao = new CarrinhoDAO();
            var carrinho = dao.busca(carrinho_id);
            carrinho.troca(produto);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
