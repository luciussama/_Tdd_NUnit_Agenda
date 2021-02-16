using Agenda.Domain;
using AutoFixture;
using NUnit.Framework;
using System;
using System.Linq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest : BaseTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        [Test]
        public void AdicionarContatoTest()
        {
            //Monta
            var contato = new Contato()
            {
                Id = _fixture.Create<Guid>(),
                Nome = _fixture.Create<string>()
            };
            

            //Executa
            _contatos.Adicionar(contato);

            Assert.True(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            //Monta
            var contato = _fixture.Create<Contato>();

            var contatoResultado = new Contato();

            //Executavar 
            _contatos.Adicionar(contato);

            contatoResultado = _contatos.Obter(contato.Id);
            //Verifica
            Assert.AreEqual(contato.Id, contatoResultado.Id);
        }
        [Test]
        public void ObterTodosOsContatosTest()
        {
            //Montar
            var contato1 = _fixture.Create<Contato>();
            var contato2 = _fixture.Create<Contato>();

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
            _fixture = null;
        }
    }
}
