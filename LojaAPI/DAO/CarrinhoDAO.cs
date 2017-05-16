using LojaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaAPI.DAO {

    public class CarrinhoDAO {

        private static Dictionary<long, Carrinho> database = new Dictionary<long, Carrinho>();
        private static long count = 1;

        static CarrinhoDAO() {
            Produto videogame = new Produto(6237, "Playstation 4", 1500, 1);
            Produto esporte = new Produto(3467, "F1 2017", 200, 1);
            Carrinho carrinho = new Carrinho();
            carrinho.adiciona(videogame);
            carrinho.adiciona(esporte);
            carrinho.Endereco = "Av. Epitácio Pessoa, 1446";
            carrinho.Id = 1;
            database.Add(1, carrinho);
        }

        public void adiciona(Carrinho carrinho) {
            count++;
            carrinho.Id = count;
            database.Add(count, carrinho);
        }

        public Carrinho busca(long id) {
            return database[id];
        }

        public void remove(long id) {
            database.Remove(id);
        }
    }
}