﻿#pragma checksum "C:\Users\Bass4Nation\Desktop\Github\dotNet-2022\RandomFacts\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "925AF74C90B027CC77FD89B62A9A5B8E8790FD3DCD4AFA8F8720F336F0F60F17"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using WinRT;

namespace RandomFacts
{
    partial class MainWindow : 
        global::Microsoft.UI.Xaml.Window, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainWindow.xaml line 27
                {
                    this.frontPage = target.As<Microsoft.UI.Xaml.Controls.Frame>();
                }
                break;
            case 3: // MainWindow.xaml line 38
                {
                    this.menuBtn = target.As<Microsoft.UI.Xaml.Controls.HyperlinkButton>();
                    ((global::Microsoft.UI.Xaml.Controls.HyperlinkButton)this.menuBtn).Click += this.MenuBtn_OnClick;
                }
                break;
            case 4: // MainWindow.xaml line 40
                {
                    this.appTitle = target.As<Microsoft.UI.Xaml.Controls.TextBlock>();
                }
                break;
            case 5: // MainWindow.xaml line 42
                {
                    this.factTitle = target.As<Microsoft.UI.Xaml.Controls.TextBlock>();
                }
                break;
            case 6: // MainWindow.xaml line 44
                {
                    this.factContent = target.As<Microsoft.UI.Xaml.Controls.TextBlock>();
                }
                break;
            case 7: // MainWindow.xaml line 46
                {
                    this.nextBtn = target.As<Microsoft.UI.Xaml.Controls.Button>();
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.nextBtn).Click += this.NextBtn_OnClick;
                }
                break;
            case 8: // MainWindow.xaml line 47
                {
                    this.sourceBtn = target.As<Microsoft.UI.Xaml.Controls.Button>();
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.sourceBtn).Click += this.SourceBtn_OnClick;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

