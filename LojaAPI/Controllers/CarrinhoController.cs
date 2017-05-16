using LojaAPI.DAO;
using LojaAPI.Models;
using System.Web.Http;

namespace LojaAPI.Controllers { 

    public class CarrinhoController : ApiController {

        //  Por padrão a API já me retorna JSON
        public Carrinho Get(int id) {
            CarrinhoDAO dao = new CarrinhoDAO();
            Carrinho carrinho = dao.busca(id);
            return carrinho;
        }

        //  Insere no meu banco de dados passando um JSON ou XML no corpo
        public string Post([FromBody] Carrinho carrinho) {
            CarrinhoDAO dao = new CarrinhoDAO();
            dao.adiciona(carrinho);
            return "Sucesso";
        }
    }
}
