using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinAplication1 {
    class Pessoa {
        #region Atributos
        public int Codigo { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        #endregion

        #region Métodos
        public static List<Pessoa> ListarPessoas() {
            List<Pessoa> pessoas = new List<Pessoa>();
            XElement xml = XElement.Load("Pessoas.xml");
            foreach(XElement x in xml.Elements()) {
                Pessoa p = new Pessoa() {
                    Codigo = int.Parse(x.Attribute("codigo").Value),
                    Nome = x.Attribute("nome").Value,
                    Telefone = x.Attribute("telefone").Value
                };
                pessoas.Add(p);
            }
            return pessoas;
        }

        public static void AdiconarPessoa(Pessoa p) {
            XElement x = new XElement("pessoa");
            x.Add(new XAttribute("codigo", p.Codigo.ToString()));
            x.Add(new XAttribute("nome", p.Nome));
            x.Add(new XAttribute("telefone", p.Telefone));
            XElement xml = XElement.Load("Pessoas.xml");
            xml.Add(x);
            xml.Save("Pessoas.xml");
        }

        public static void ExcluirPessoa(int codigo) {
            XElement xml = XElement.Load("Pessoas.xml");
            XElement x = xml.Elements().Where(p => p.Attribute("codigo").Value.Equals(codigo.ToString())).First();
            if (x != null) {
                x.Remove();
            }
            xml.Save("Pessoas.xml");
        }

        public static void EditarPessoa(Pessoa pessoa) {
            XElement xml = XElement.Load("Pessoas.xml");
            XElement x = xml.Elements().Where(p => p.Attribute("codigo").Value.Equals(pessoa.Codigo.ToString())).First();
            if (x != null) {
                x.Attribute("nome").SetValue(pessoa.Nome);
                x.Attribute("telefone").SetValue(pessoa.Telefone);
            }
            xml.Save("Pessoas.xml");
        }
        #endregion

    }
}
