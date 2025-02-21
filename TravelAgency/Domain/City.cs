﻿// <copyright file="City.cs" company="Самофалов А.П.">
// Copyright (c) Самофалов А.П.. All rights reserved.
// </copyright>
namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff;

    /// <summary>
    /// Класс город
    /// </summary>
    public class City
    {
        public City()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="City"/>.
        /// </summary>
        /// /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="nameCity">Название города</param>
        public City (int id, string nameCity)
        {
            this.Id = id;
            this.NameCity = nameCity.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(nameCity));
        }

        /// <summary>
        /// Получает или задает уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Получает или задает название города
        /// </summary>
        public string NameCity { get; set; }

        /// <summary>
        /// Получает или задает объект страны.
        /// </summary>
        public virtual Country Country { get; set; }

        public virtual ISet<Attraction> Attractions { get; set; } = new HashSet<Attraction>();

        /// <summary>
        /// Добавить достопримечательность городу.
        /// </summary>
        /// <param name="attraction">Добавляемая достопримечательность</param>
        /// <returns>
        /// <see langword="true"/> если достопримечательность была добавлен.
        /// </returns>
        public bool AddAttraction(Attraction attraction) => this.Attractions.TryAdd(attraction) ?? throw new ArgumentNullException(nameof(attraction));

        public override string ToString() => this.NameCity;
    }
}