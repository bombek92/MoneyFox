﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using MoneyFox.Application;
using MoneyFox.Presentation.Converter;
using Should;
using Xunit;

namespace MoneyFox.Presentation.Tests.Converter
{
    [ExcludeFromCodeCoverage]
    public class ShortDateFormatConverterTests
    {
        [Fact]
        public void Convert_DateTime_ValidString()
        {
            CultureHelper.CurrentCulture = new CultureInfo("en-US");
            var date = new DateTime(2015, 09, 15, 14, 56, 48);
            new ShortDateFormatConverter().Convert(date, null, null, null).ShouldEqual(date.ToString("d", CultureHelper.CurrentCulture));
        }
    }
}
