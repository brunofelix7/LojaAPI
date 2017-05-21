using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace LojaAPI.Models {

    public class Carrinho {

        public long Id { get; set; }
        public List<Produto> Produtos { get; set; }
        public string Endereco { get; set; }

        public Carrinho() {
            this.Produtos = new List<Produto>();
        }

        public void adiciona(Produto produto) {
            this.Produtos.Add(produto);
        }     

        public void remove(long id) { 
            Produto produto = this.Produtos.FirstOrDefault(p => p.Id == id);
            this.Produtos.Remove(produto);
        }

        public void troca(Produto produto) {
            remove(produto.Id);
            adiciona(produto);
        }

        public void trocaEndereco(string endereco) {
            this.Endereco = endereco;
        }

        public string ToXml() {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Carrinho));
            StringWriter streamWriter = new StringWriter();
            using(XmlWriter xmlWriter = XmlWriter.Create(streamWriter)) {
                xmlSerializer.Serialize(xmlWriter, this);
            }
            return streamWriter.ToString();
        }
    }
}