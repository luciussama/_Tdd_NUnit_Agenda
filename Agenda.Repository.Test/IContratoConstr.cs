using Agenda.Domain;
using AutoFixture;
using Moq;
using System;

namespace Agenda.Repository.Test
{
    class IContratoConstr
    {
        Mock<IContato> _mContato;
        Fixture _fixture;

        public IContratoConstr(Mock<IContato> mContato, Fixture fixture)
        {
            _mContato = mContato;
            _fixture = fixture;
        }

        public static IContratoConstr Um()
        {
            return new IContratoConstr(new Mock<IContato>(), new Fixture());
        }

        public IContato Construir()
        {
            return _mContato.Object;
        }

        public Mock<IContato> Obter()
        {
            return _mContato;
        }

        public IContratoConstr ComNome(string nome)
        {
            _mContato.SetupGet(c => c.Nome).Returns(nome);
            return this;
        }
        public IContratoConstr ComId(Guid id)
        {
            _mContato.SetupGet(c => c.Id).Returns(id);
            return this;
        }
    }
}
