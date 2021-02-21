using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain;
using Agenda.Repository;
using NUnit.Framework;
using Moq;
using Agenda.DAL;

namespace Agenda.Repository.Test
{
    [TestFixture]
    public class RepositorioContatosTest
    {
        Mock<IContatos> _contatos;
        Mock<ITelefones> _telefones;

        RepositorioContatos _repositorioContatos;
        
        [SetUp]
        public void Setup() {
            _contatos = new Mock<IContatos>();
            _telefones = new Mock<ITelefones>();
            _repositorioContatos = new RepositorioContatos(_contatos.Object, _telefones.Object);
        }

        [Test]
        public void DeveSerPossivelObterContatoComListaTelefone()
        {
            //Arrange
            var listTelefone = new List<ITelefone>();
            var telefoneId = Guid.NewGuid();
            var contatoId = Guid.NewGuid();

            //Mock da interface testada
            ITelefone mTelefone = ITelefoneConstr.Um().ValorPadrao()
                .ComId(telefoneId)
                .ComContatoId(contatoId)
                .Construir();

            Mock<IContato> mContato = IContratoConstr.Um()
                .ComId(contatoId).ComNome("Sérgio")
                .Obter();

            mContato.SetupSet(c => c.Telefones = It.IsAny<List<ITelefone>>())
                .Callback<List<ITelefone>>(t => listTelefone = t);

            //Moq da função da classe a ser testada
            _contatos.Setup(cs => cs.Obter(contatoId)).Returns(mContato.Object);
            _telefones.Setup(ts => ts.ObterTodosDoContato(contatoId)).Returns(new List<ITelefone> { mTelefone });

            //Assert
            //Tester os métodos da classe mockada
            var contatoResultado = _repositorioContatos.ObterPorId(contatoId);
            mContato.SetupGet(c => c.Telefones).Returns(listTelefone);


            //Act
            //Validar o retorno dos métodos mockados
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mContato.Object.Nome, contatoResultado.Nome);
            Assert.AreEqual(1, mContato.Object.Telefones.Count);
            Assert.AreEqual(mTelefone.Numero, contatoResultado.Telefones[0].Numero);
            Assert.AreEqual(mTelefone.Id, contatoResultado.Telefones[0].Id);
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Telefones[0].ContatoId);
        }
        
        
        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _telefones = null;
            _repositorioContatos = null;
        }
    }
}
