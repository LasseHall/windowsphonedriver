﻿// <copyright file="CommandHandlerFactory.cs" company="Salesforce.com">
//
// Copyright (c) 2014 Salesforce.com, Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the
// following conditions are met:
//
//    Redistributions of source code must retain the above copyright notice, this list of conditions and the following
//    disclaimer.
//
//    Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the
//    following disclaimer in the documentation and/or other materials provided with the distribution.
//
//    Neither the name of Salesforce.com nor the names of its contributors may be used to endorse or promote products
//    derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPhoneDriverBrowser.CommandHandlers;

namespace WindowsPhoneDriverBrowser
{
    /// <summary>
    /// A class for producing <see cref="CommandHandler"/> objects, given a command name.
    /// </summary>
    public sealed class CommandHandlerFactory
    {
        private static CommandHandlerFactory factory;

        private Dictionary<string, CommandHandler> handlers = new Dictionary<string, CommandHandler>();

        /// <summary>
        /// Prevents a default instance of the <see cref="CommandHandlerFactory"/> class from being created.
        /// </summary>
        private CommandHandlerFactory()
        {
            this.PopulateCommandHandlers();
        }

        /// <summary>
        /// Gets the singleton instance of the <see cref="CommandHandlerFactory"/>.
        /// </summary>
        public static CommandHandlerFactory Instance
        {
            get
            {
                if (factory == null)
                {
                    factory = new CommandHandlerFactory();
                }

                return factory;
            }
        }

        /// <summary>
        /// Gets a <see cref="CommandHandler"/> for the specified command name.
        /// </summary>
        /// <param name="commandName">The name of the command for which to get the command handler.</param>
        /// <returns>The <see cref="CommandHandler"/> for the command. Returns a <see cref="NotImplementedCommandHandler"/>
        /// if the command is not implemented.</returns>
        internal CommandHandler GetHandler(string commandName)
        {
            CommandHandler handler = null;
            if (this.handlers.TryGetValue(commandName, out handler))
            {
                return handler;
            }

            return new NotImplementedCommandHandler(commandName);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Factory method requires class coupling to avoid reflection")]
        private void PopulateCommandHandlers()
        {
            this.handlers.Add(DriverCommand.Status, new StatusCommandHandler());
            this.handlers.Add(DriverCommand.NewSession, new NewSessionCommandHandler());
            this.handlers.Add(DriverCommand.Get, new GoToUrlCommandHandler());
            this.handlers.Add(DriverCommand.GetCurrentUrl, new GetCurrentUrlCommandHandler());
            this.handlers.Add(DriverCommand.GetTitle, new GetTitleCommandHandler());
            this.handlers.Add(DriverCommand.GetPageSource, new GetPageSourceCommandHandler());
            this.handlers.Add(DriverCommand.GoForward, new GoForwardCommandHandler());
            this.handlers.Add(DriverCommand.GoBack, new GoBackCommandHandler());
            this.handlers.Add(DriverCommand.Refresh, new RefreshCommandHandler());
            this.handlers.Add(DriverCommand.SwitchToFrame, new SwitchToFrameCommandHandler());
            this.handlers.Add(DriverCommand.SwitchToWindow, new SwitchToWindowCommandHandler());
            this.handlers.Add(DriverCommand.ElementEquals, new ElementEqualsCommandHandler());
            this.handlers.Add(DriverCommand.GetActiveElement, new GetActiveElementCommandHandler());
            this.handlers.Add(DriverCommand.FindElement, new FindElementCommandHandler());
            this.handlers.Add(DriverCommand.FindElements, new FindElementsCommandHandler());
            this.handlers.Add(DriverCommand.FindChildElement, new FindChildElementCommandHandler());
            this.handlers.Add(DriverCommand.FindChildElements, new FindChildElementsCommandHandler());
            this.handlers.Add(DriverCommand.ClickElement, new ClickElementCommandHandler());
            this.handlers.Add(DriverCommand.ClearElement, new ClearElementCommandHandler());
            this.handlers.Add(DriverCommand.SendKeysToElement, new SendKeysCommandHandler());
            this.handlers.Add(DriverCommand.GetElementAttribute, new GetElementAttributeValueCommandHandler());
            this.handlers.Add(DriverCommand.GetElementText, new GetElementTextCommandHandler());
            this.handlers.Add(DriverCommand.GetElementLocation, new GetElementLocationCommandHandler());
            this.handlers.Add(DriverCommand.GetElementSize, new GetElementSizeCommandHandler());
            this.handlers.Add(DriverCommand.GetElementValueOfCssProperty, new GetElementCssPropertyValueCommandHandler());
            this.handlers.Add(DriverCommand.GetElementTagName, new GetElementTagNameCommandHandler());
            this.handlers.Add(DriverCommand.GetElementLocationOnceScrolledIntoView, new GetElementLocationInViewCommandHandler());
            this.handlers.Add(DriverCommand.IsElementDisplayed, new IsElementDisplayedCommandHandler());
            this.handlers.Add(DriverCommand.IsElementEnabled, new IsElementEnabledCommandHandler());
            this.handlers.Add(DriverCommand.IsElementSelected, new IsElementSelectedCommandHandler());
            this.handlers.Add(DriverCommand.SubmitElement, new SubmitCommandHandler());
            this.handlers.Add(DriverCommand.ExecuteScript, new ExecuteScriptCommandHandler());
            this.handlers.Add(DriverCommand.ExecuteAsyncScript, new ExecuteAsyncScriptCommandHandler());
            this.handlers.Add(DriverCommand.ImplicitlyWait, new SetImplicitWaitTimeoutCommandHandler());
            this.handlers.Add(DriverCommand.SetAsyncScriptTimeout, new SetAsyncScriptTimeoutCommandHandler());
            this.handlers.Add(DriverCommand.SetTimeout, new SetTimeoutCommandHandler());
            this.handlers.Add(DriverCommand.Quit, new QuitCommandHandler());
            this.handlers.Add(DriverCommand.Close, new QuitCommandHandler());
            this.handlers.Add(DriverCommand.AddCookie, new AddCookieCommandHandler());
            this.handlers.Add(DriverCommand.GetAllCookies, new GetAllCookiesCommandHandler());
            this.handlers.Add(DriverCommand.DeleteCookie, new DeleteCookieCommandHandler());
            this.handlers.Add(DriverCommand.DeleteAllCookies, new DeleteAllCookiesCommandHandler());
            this.handlers.Add(DriverCommand.GetCurrentWindowHandle, new GetCurrentWindowHandleCommandHandler());
            this.handlers.Add(DriverCommand.GetWindowHandles, new GetWindowHandlesCommandHandler());
            this.handlers.Add(DriverCommand.GetWindowPosition, new GetWindowPositionCommandHandler());
            this.handlers.Add(DriverCommand.GetWindowSize, new GetWindowSizeCommandHandler());
            this.handlers.Add(DriverCommand.SetWindowPosition, new NoOpCommandHandler());
            this.handlers.Add(DriverCommand.SetWindowSize, new NoOpCommandHandler());
            this.handlers.Add(DriverCommand.MaximizeWindow, new NoOpCommandHandler());
            this.handlers.Add(DriverCommand.GetOrientation, new GetOrientationCommandHandler());
            this.handlers.Add(DriverCommand.SendKeysToActiveElement, new SendKeysToActiveElementCommandHandler());
            this.handlers.Add(DriverCommand.MouseClick, new MouseClickCommandHandler());
            this.handlers.Add(DriverCommand.MouseMoveTo, new MouseMoveCommandHandler());
            this.handlers.Add(DriverCommand.MouseDown, new MouseButtonDownCommandHandler());
            this.handlers.Add(DriverCommand.MouseUp, new MouseButtonUpCommandHandler());
            this.handlers.Add(DriverCommand.MouseDoubleClick, new MouseDoubleClickCommandHandler());
            this.handlers.Add(DriverCommand.Screenshot, new ScreenshotCommandHandler());
        }
    }
}
