﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateNet
{

    public delegate void Notificacao();
    public class Lista
    {
        private List<Lista> _items = new List<Lista>();
        public int Id { get; set; }
        public string Item { get; set; }
        public DateTime DataCriacao => DateTime.Now;
        public IReadOnlyCollection<Lista> GetListas => _items;
        public event Notificacao Notificar;

        public void Add(string item)
        {
            var itemLista = new Lista();
            itemLista.Id += this._items.Count;
            itemLista.Item = item;
            this._items.Add(itemLista);
            EventHandler();
        }
        private void EventHandler()
        {
            Notificar();
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.Item} - {this.DataCriacao}";
        }

        #region Func
        public Lista GetItemById(Func<Lista,bool> func)
        {
            return this._items.FirstOrDefault(func);
        }
        #endregion

        #region Action
        public void PrintAllItems(Action<Lista> action)
        //public void PrintAllItems()
        {
            this._items.ForEach(action);

            //Delegate Anonimo
            //this._items.ForEach(s =>
            //{
            //    Console.WriteLine(s);
            //});
        }
        #endregion

        #region Precidate
        public bool ExistItem(Predicate<Lista> predicate)
        {
            return this._items.Exists(predicate);
        }
        #endregion
    }
}
