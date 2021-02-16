using Agenda.Domain;
using NUnit.Framework;
using System;
using System.Linq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest
    {
        Contatos _contatos;

        [SetUp]
        public void Setup()
        {
            _contatos = new Contatos();
        }

        [Test]
        public void AdicionarContatoTest()
        {
            //Monta
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Oliver"
            };
            

            //Executa
            _contatos.Adicionar(contato);

            Assert.True(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            //Monta
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Juzé dos burro"
            };
            var contatoResultado = new Contato();

            //Executa
            _contatos.Adicionar(contato);

            contatoResultado = _contatos.Obter(contato.Id);
            //Verifica
            Assert.AreEqual(contato.Id, contatoResultado.Id);
        }
        [Test]
        public void ObterTodosOsContatosTest()
        {
            //Montar
            var contato1 = new Contato() { Id = Guid.NewGuid(), Nome = "Maria" };
            var contato2 = new Contato() { Id = Guid.NewGuid(), Nome = "Zé da porra" };

            //Executa
            _contatos.Adicionar(contato1); _contatos.Adicionar(contato2);
            var lstContato = _contatos.ObterTodos();

            var contatoResultado = lstContato.Where(c => c.Id == contato1.Id).FirstOrDefault();

            //Verifica
            Assert.IsTrue(lstContato.Count > 1);
            Assert.AreEqual(contato1.Id, contatoResultado.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }
    }
}
