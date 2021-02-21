using Agenda.Domain;
using AutoFixture;
using Moq;
using System;

namespace Agenda.Repository.Test
{
    public class ITelefoneConstr
    {
        Mock<ITelefone> _mTelefone;
        Fixture _fixture;

        protected ITelefoneConstr(Mock<ITelefone> mtelefone, Fixture fixture)
        {
            _mTelefone = mtelefone;
            _fixture = fixture;
        }
        public static ITelefoneConstr Um()
        {
            return new ITelefoneConstr(new Mock<ITelefone>(), new Fixture());
        }

        public ITelefoneConstr ValorPadrao()
        {
            _mTelefone.SetupGet(t => t.Id).Returns(_fixture.Create<Guid>());
            _mTelefone.SetupGet(t => t.Numero).Returns(_fixture.Create<string>());
            _mTelefone.SetupGet(t => t.ContatoId).Returns(_fixture.Create<Guid>());
            return this;
        }

        public ITelefone Construir()
        {
            return _mTelefone.Object;
        }
        public ITelefoneConstr ComId(Guid id)
        {
            _mTelefone.SetupGet(t => t.Id).Returns(id);
            return this;
        }
        public ITelefoneConstr ComNumero(string numero)
        {
            _mTelefone.SetupGet(t => t.Numero).Returns(numero);
            return this;
        }
        public ITelefoneConstr ComContatoId(Guid contatoId)
        {
            _mTelefone.SetupGet(t => t.ContatoId).Returns(contatoId);
            return this;
        }
    }
}
