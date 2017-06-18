using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathematicalLingusticsTask6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LLOneParser Parser { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            InitializeGrammar();
        }

        private void InitializeGrammar()
        {
            var o = new Production()
            {
                Character = 'O',
                Expressions = new List<Expression>()
                {
                    new Expression()
                    {
                        Symbols = new List<ISymbol>
                        {
                            new RegularSymbol('*'),
                            new RegularSymbol(':'),
                            new RegularSymbol('+'),
                            new RegularSymbol('-'),
                            new RegularSymbol('^')
                        }
                    }
                }
            };

            var c = new Production()
            {
                Character = 'C',
                Expressions = new List<Expression>()
                {
                    new Expression()
                    {
                        Symbols = new List<ISymbol>()
                        {
                            new RegularSymbol('0'),
                            new RegularSymbol('1'),
                            new RegularSymbol('2'),
                            new RegularSymbol('3'),
                            new RegularSymbol('4'),
                            new RegularSymbol('5'),
                            new RegularSymbol('6'),
                            new RegularSymbol('7'),
                            new RegularSymbol('8'),
                            new RegularSymbol('9')
                        }
                    }
                }
            };


            var lPrime = new Production()
            {
                Character = 'Ł', // L'
                Expressions = new List<Expression>()
                {
                    new Expression()
                    {
                        Symbols = new List<ISymbol>()
                        {
                            new EmptySign()
                        }
                    }
                }
            };

            var l = new Production()
            {
                Character = 'L',
                Expressions = new List<Expression>()
                {
                    new Expression()
                    {
                        Symbols = new List<ISymbol>()
                        {
                            c,
                            lPrime
                        }
                    }
                }
            };

            lPrime.Expressions.Add(
                new Expression()
                {
                    Symbols = new List<ISymbol>()
                    {
                        l
                    }
                });

            var rPrime = new Production()
            {
                Character = 'X', // R'
                Expressions = new List<Expression>()
                {
                    new Expression()
                    {
                        Symbols = new List<ISymbol>()
                        {
                            new EmptySign()
                        }
                    },
                    new Expression()
                    {
                        Symbols = new List<ISymbol>()
                        {
                            new RegularSymbol('.'),
                            l
                        }
                    }
                }
            };

            var r = new Production()
            {
                Character = 'R',
                Expressions = new List<Expression>()
                {
                    new Expression()
                    {
                        Symbols = new List<ISymbol>()
                        {
                            l,
                            rPrime
                        }
                    }
                }
            };

            var p = new Production()
            {
                Character = 'P',
                Expressions = new List<Expression>()
                {
                    new Expression()
                    {
                        Symbols = new List<ISymbol>()
                        {
                            r
                        }
                    }
                }
            };

            var wPrime = new Production()
            {
                Character = 'V',
                Expressions = new List<Expression>()
                {
                    new Expression()
                    {
                        Symbols = new List<ISymbol>()
                        {
                            new EmptySign()
                        }
                    },
                }
            };

            var w = new Production()
            {
                Character = 'W',
                Expressions = new List<Expression>()
                {
                    new Expression()
                    {
                        Symbols = new List<ISymbol>
                        {
                            p,
                            wPrime
                        }
                    }
                }
            };

            wPrime.Expressions.Add(
                new Expression()
                {
                    Symbols = new List<ISymbol>()
                    {
                        o,
                        w
                    }
                });

            var z = new Production()
            {
                Character = 'Z'
            };

            z.Expressions = new List<Expression>()
            {
                new Expression()
                {
                    Symbols = new List<ISymbol>()
                    {
                        w,
                        new RegularSymbol(';'),
                        z
                    }
                },
                new Expression()
                {
                    Symbols = new List<ISymbol>()
                    {
                        new EmptySign()
                    }
                }
            };

            var s = new Production()
            {
                Character = 'S',
                Expressions = new List<Expression>()
                {
                    new Expression()
                    {
                        Symbols = new List<ISymbol>()
                        {
                            w,
                            new RegularSymbol(';'),
                            z
                        }
                    }
                }
            };

            Parser = new LLOneParser()
            {
                Grammar = new Grammar()
                {
                    Productions = new HashSet<Production>()
                    {
                        s,
                        z,
                        w,
                        wPrime,
                        p,
                        r,
                        rPrime,
                        l,
                        lPrime,
                        c,
                        o
                    },
                    HeadProduction = s
                }
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Parser.Parse(txtInput.Text))
            {
                txtOutput.Text = "Valid";
                txtOutput.Foreground = new SolidColorBrush(Color.FromRgb(50, 255, 50));
            }
            else
            {
                txtOutput.Text = "Invalid";
                txtOutput.Foreground = new SolidColorBrush(Color.FromRgb(255, 50, 50));
            }
        }
    }
}
