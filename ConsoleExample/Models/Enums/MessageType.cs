﻿using System.ComponentModel;

namespace ConsoleExample.Models.Enums
{
    /// <summary>
    /// Типы сообщения для рекламы
    /// </summary>
    public enum MessageType
    {
        [Description("Текст")]
        Text = 0,
        [Description("Фото")]
        Photo,
        [Description("Видео")]
        Video,
        [Description("Документ")]
        Document,
    }
}
