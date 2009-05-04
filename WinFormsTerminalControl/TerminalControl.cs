﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TerminalCore;
using TerminalCore.Model;

using SizeF=System.Drawing.SizeF;

namespace WinFormsTerminalControl
{
	public partial class TerminalControl : UserControl, ITerminalView
	{
		protected float m_charWidth;
		protected float m_charHeight;
		protected TerminalController m_terminal;

		public TerminalControl()
		{
			InitializeComponent();
			
			SetStyle( ControlStyles.DoubleBuffer, true );
			SetStyle( ControlStyles.UserPaint, true );
			SetStyle( ControlStyles.AllPaintingInWmPaint, true );
			
			MeasureFont();
			m_terminal = new TerminalController( this, "tst> " );
		}

		private void MeasureFont()
		{
			using( Graphics g = CreateGraphics() )
			{
				SizeF size = g.MeasureString( "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", Font );
				m_charWidth = size.Width / 400F;
				m_charHeight = size.Height;
			}
		}

		private void TerminalControl_Paint( object sender, PaintEventArgs e )
		{
			Color color = ForeColor;
			using( Brush brush = new SolidBrush( color ) )
			{
				e.Graphics.DrawString(
					m_terminal.Prompt,
					Font,
					brush,
					(float)(0 * m_charWidth),
					(float)(0 * m_charHeight) );
			}
		}

		public TerminalCore.Model.SizeF MeasureText( string text, SpanFont font )
		{
			throw new NotImplementedException();
		}
	}
}
