using Agenda.DAL;
using Agenda.Domain;
using System;
using System.Collections.Generic;

namespace Agenda.Repository
{
    public class RepositorioContatos
    {
        private readonly IContatos _contatos;
        private readonly ITelefones _telefones;

        public RepositorioContatos(IContatos contatos, ITelefones telefones)
        {
            _contatos = contatos;
            _telefones = telefones;
        }

        public IContato ObterPorId(Guid id)
        {
            IContato contato = _contatos.Obter(id);
            List<ITelefone> telefones = _telefones.ObterTodosDoContato(id);
            contato.Telefones = telefones;
       
            return contato;
        }
    }
}
