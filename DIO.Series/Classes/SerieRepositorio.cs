using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie> //trazendo os métodos da interface IRepositorio
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir(); //marcando o id como excluído
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto); //apenas adiona o objeto na lista
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count; //um número na frente
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}