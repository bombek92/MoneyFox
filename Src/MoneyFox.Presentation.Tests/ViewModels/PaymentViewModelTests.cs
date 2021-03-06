﻿using System;
using System.Diagnostics.CodeAnalysis;
using MediatR;
using MoneyFox.Presentation.Services;
using MoneyFox.Presentation.ViewModels;
using Moq;
using Should;
using Xunit;

namespace MoneyFox.Presentation.Tests.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class PaymentViewModelTests
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly Mock<INavigationService> navigationService;

        public PaymentViewModelTests()
        {
            mediatorMock = new Mock<IMediator>();
            navigationService = new Mock<INavigationService>();
        }

        [Fact]
        public void Ctor_SetDefaults()
        {
            // Arrange

            // Act
            var vm = new PaymentViewModel(mediatorMock.Object, navigationService.Object);

            // Assert
            vm.IsRecurring.ShouldBeFalse();
            vm.Date.Date.ShouldEqual(DateTime.Today);
        }

        [Fact]
        public void IsRecurring_SetTrue_CreateRecurringViewModel()
        {
            // Arrange
            var vm = new PaymentViewModel(mediatorMock.Object, navigationService.Object);
            vm.RecurringPayment.ShouldBeNull();

            // Act
            vm.IsRecurring = true;

            // Assert.
            vm.RecurringPayment.ShouldNotBeNull();
        }

        [Fact]
        public void IsRecurring_SetFalse_RecurringViewModelSetNull()
        {
            // Arrange
            var vm = new PaymentViewModel(mediatorMock.Object, navigationService.Object) {IsRecurring = true};
            vm.RecurringPayment.ShouldNotBeNull();

            // Act
            vm.IsRecurring = false;

            // Assert.
            vm.RecurringPayment.ShouldBeNull();
        }
    }
}
