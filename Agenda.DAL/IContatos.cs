using Agenda.Domain;
using System;
using System.Collections.Generic;

namespace Agenda.DAL
{
    public interface IContatos
    {
        void Adicionar(Contato contato);
        IContato Obter(Guid id);
        List<Contato> ObterTodos();
    }
}
