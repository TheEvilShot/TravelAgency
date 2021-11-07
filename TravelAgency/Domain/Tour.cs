﻿// <copyright file="Tour.cs" company="Самофалов А.П.">
// Copyright (c) Самофалов А.П. All rights reserved.
// </copyright>

using Staff;
using Staff.Extensions;

namespace Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Тур.
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Tour"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор</param>
        /// <param name="nameTour">Название тура</param>
        /// <param name="maxTourists">Максимальное количество туристов</param>
        /// <param name="tourists">Список туристов</param>
        /// <param name="dateStart">Дата начала тура</param>
        /// <param name="price">Цена</param>
        /// <param name="dateEnd">Дата окончания тура</param>
        public Tour(int id, string nameTour, DateTime dateStart, int price, DateTime dateEnd, int maxTourists,
            params Tourist[] tourists)
            : this(id, nameTour, dateStart, price, dateEnd, maxTourists,
#pragma warning disable SA1117 // Parameters should be on same line or separate lines
            new HashSet<Tourist>(tourists))
#pragma warning restore SA1117 // Parameters should be on same line or separate lines
        { }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Tour"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nameTour"></param>
        /// <param name="dateStart"></param>
        /// <param name="price"></param>
        /// <param name="dateEnd"></param>
        /// <param name="maxTourists"></param>
        /// <param name="tourists"></param>
        public Tour(int id, string nameTour, DateTime dateStart, int price, DateTime dateEnd, int maxTourists,
            ISet<Tourist> tourists = null, ISet<Hotel> hotels = null, Employee employee = null, ISet<Transport> transports = null)
        {
            this.Id = id;
            this.DateStart = dateStart;
            this.Price = price;
            this.DateEnd = dateEnd;
            this.MaxTourists = maxTourists;
            this.NameTour = nameTour.TrimOrNull() ?? throw new ArgumentNullException(nameof(nameTour));

            if (tourists != null)
            {
                foreach (var tourist in tourists)
                {
                    this.Tourists.Add(tourist);
                    tourist.AddTour(this);
                }
            }

            if (hotels != null)
            {
                foreach (var hotel in hotels)
                {
                    this.Hotels.Add(hotel);
                    hotel.AddTour(this);
                }
            }

            if (employee != null)
            {
                this.Employee = employee;
            }

            if(transports != null)
            {
                foreach (var transport in transports)
                {
                    this.Transports.Add(transport);
                    transport.AddTour(this);
                }
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Tour"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nameTour"></param>
        /// <param name="dateStart"></param>
        /// <param name="price"></param>
        /// <param name="dateEnd"></param>
        /// <param name="maxTourists"></param>
        public Tour(int id, string nameTour, DateTime dateStart, int price, DateTime dateEnd, int maxTourists)
        {
            this.Id = id;
            this.DateStart = dateStart;
            this.Price = price;
            this.DateEnd = dateEnd;
            this.MaxTourists = maxTourists;
            this.NameTour = nameTour.TrimOrNull() ?? throw new ArgumentNullException(nameof(nameTour));
        }

        /// <summary>
        /// Получает или задает уникальный идентификатор.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Получает или задает  название тура.
        /// </summary>
        public string NameTour { get; set; }

        /// <summary>
        /// Получает или задает цену тура
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Получает или задает дату начала тура.
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Получает или задает дату окончания тура.
        /// </summary>
        public DateTime DateEnd { get; set; }

        /// <summary>
        /// Получает или задает максимальное количество туристов.
        /// </summary>
        public int MaxTourists { get; set; }

        /// <summary>
        /// Получает или задает сотрудника тура
        /// </summary>
        public virtual Employee Employee { get; set; }
        /// <summary>
        /// Получает или задает список туристов.
        /// </summary>
        public virtual ISet<Tourist> Tourists { get; protected set; } = new HashSet<Tourist>();

        /// <summary>
        /// Получает или задает список отелей.
        /// </summary>
        public virtual ISet<Hotel> Hotels { get; protected set; } = new HashSet<Hotel>();

        /// <summary>
        /// Получает или задает список транспорта
        /// </summary>
        public virtual ISet<Transport> Transports { get; set; } = new HashSet<Transport>();

        /// <inheritdoc/>
        public override string ToString() => $"{this.NameTour} {this.DateStart}{this.DateEnd} {this.Price} {this.MaxTourists} {this.Tourists.Join()} {this.Hotels.Join()} {this.Employee}";
    }
}
