using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Microchip_Hash_Table_Filter_Entry_Calculator_ReBuild
{

    public partial class Form1 : Form
	{
		public class CalcTable
		{
			private byte[] mac_addr = new byte[6];
			private uint crc32_result;
			private UInt16 hash_table_index;
			private byte hash_value;
			private UInt64 matches;

			public void Clear()
			{
				mac_addr = new byte[6] {0,0,0,0,0,0};
				crc32_result = 0;
				hash_table_index = 0;
				hash_value = 0;
				matches = 0;
			}

			public byte[] MAC_Address
			{
				get { return (mac_addr); }
				set { mac_addr = value; }
			}

			public uint CRC32_Result
			{
				get { return (crc32_result); }
				set { crc32_result = value; }
			}

			public UInt16 Hash_Table_Index
			{
				get { return (hash_table_index); }
				set { hash_table_index = value; }
			}

			public byte Hash_Value
			{
				get { return (hash_value); }
				set { hash_value = value; }
			}

			public UInt64 Match
			{
				get { return (matches); }
				set { matches = value; }
			}
		}

		public Form1()
        {
            InitializeComponent();
        }

		public UInt32 polynomial = 0;   //	0x04C11DB7;
		public UInt32 crc_initial_value = 0;	//	0xffffffff;
		public UInt16 hash_table_size = 8;
		public byte[] mac_address;// = new byte[6] {0,0,0,0,0,0};
		public byte[] hash_table;// = new byte[8] {0,0,0,0,0,0,0,0};
		public UInt32[] crc32_results;
		public byte crc_counter = 0;
		public CalcTable[] results;

		UInt32 CalcCrc(byte[] data, UInt16 length, UInt32 initial_value, UInt32 polynomial)
		{
			UInt16 i, j;
			UInt32 crc = initial_value;
			
			//Loop through data
			for (i = 0; i < length; i++)
			{
				//The message is processed bit by bit
				for (j = 0; j < 8; j++)
				{
					//Update CRC value
					if ((((crc >> 31) ^ (data[i] >> j)) & 0x01) != 0)
					{
						crc = (crc << 1) ^ polynomial;
					}
					else
					{
						crc = crc << 1;
					}
				}
			}
			//Return CRC value
			return crc;
		}

		void CalcHashTable(byte[] hashtable, byte[] mac_addresses, byte num_of_addr)
		{
			UInt16 i = 0, k = 0, j = 0;
			//UInt32 crc = 0;
			UInt16 hash_index = 0;
			byte hash_result = 0;

			for (; i < num_of_addr; i++, crc_counter++)
			{
				//Compute CRC over the current MAC address
				crc32_results[crc_counter] = CalcCrc(mac_addresses, 6, crc_initial_value, polynomial);				
				//Calculate the corresponding index in the table
				k = (UInt16)((crc32_results[crc_counter] >> 23) & 0x3F);
				//Update hash table contents
				hashtable[k / hash_table_size] |= (byte)(1 << (k % hash_table_size));
				hash_index = (byte)(k / hash_table_size);
				hash_result = (byte)(1 << (k % hash_table_size));

				results[crc_counter] = new CalcTable();
				results[crc_counter].Clear();
				results[crc_counter].CRC32_Result = crc32_results[crc_counter];
				results[crc_counter].MAC_Address = mac_addresses;
				results[crc_counter].Hash_Table_Index = hash_index;
				results[crc_counter].Hash_Value = hash_result;

				rtextbox_results.Text += "MAC[" + crc_counter.ToString("X02") + "]:	";
				for(j = 0; j < 5; j++ )
				{
					rtextbox_results.Text += mac_addresses[j].ToString("X02") + ":";
				}
				rtextbox_results.Text += mac_addresses[5].ToString("X02");

				rtextbox_results.Text += "	CRC32: " + crc32_results[crc_counter].ToString("X08");
				rtextbox_results.Text += "	EHT[" + hash_index.ToString() + "] = 0x" + hash_result.ToString("X02") + "\r\n";
			}
		}

		public byte[] ConvertHexStringToByteArray(string hexString)
		{
			byte[] data = new byte[hexString.Length / 2];
			for (int index = 0; index < data.Length; index++)
			{
				string byteValue = hexString.Substring(index * 2, 2);
				data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			}
			return data;
		}

		public void Matches(CalcTable[] hash_results)
		{
			//UInt64 index = 0;
			bool match_found = false;

			rtextbox_results.Text += "\r\nSearching for Hash Matches...\r\n";

			for (uint i = 0; i < hash_results.Length; i++ )
			{
				for (uint x = 0; x < hash_results.Length; x++)
				{
					if(x != i)
					{
						if (hash_results[i].Hash_Table_Index == hash_results[x].Hash_Table_Index)
						{
							if (hash_results[i].Hash_Value == hash_results[x].Hash_Value)
							{
								hash_results[i].Match |= (UInt64)Math.Pow(2, (x));
								match_found = true;
							}
						}
					}
				}
			}

			if(match_found)
			{
				rtextbox_results.Text += "Hash Match Found!\r\n";
			}
			else
			{
				rtextbox_results.Text += "Hash Match Not Found!\r\n";
			}

			for (uint i = 0; i < hash_results.Length; i++)
			{
				if(hash_results[i].Match != 0)
				{
					rtextbox_results.Text += "MAC[" + i.ToString("X02") + "] Hash Matches with:\r\n";
					UInt64 temp_match = hash_results[i].Match;

					for (UInt32 shift_count = 0; shift_count < hash_results.Length; shift_count++, temp_match>>=1)
					{
						if((temp_match & 0x1) == 1)
						{
							rtextbox_results.Text += "MAC[" + shift_count.ToString("X02") + "]\r\n";
						}
					}
				}
			}

			//return (index);
		}

		public void handle_keystrokes(KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar))
			{
				// Check for a naughty character in the KeyDown event.
				if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^+^a-f^+^A-F^]"))
				{
					// Stop the character from being entered into the control since it is illegal.
					e.Handled = true;
				}
			}
		}

		public bool String_Is_HEX_Compilant(string text)
		{
			bool ret = false;
			// Stop the character from being entered into the control since it is illegal.
			if (System.Text.RegularExpressions.Regex.IsMatch(text, @"[^0-9^+^a-f^+^A-F^]"))
			{
				// Stop the character from being entered into the control since it is illegal.
				ret = true;
			}
			return (ret);
		}

		private void btn_calc_Click(object sender, EventArgs e)
		{
			bool error = false;
			crc_counter = 0;
			//hash_table_size = (UInt16)hash_table_cnt_nud.Value;
			hash_table = new byte[hash_table_size];
			crc32_results = new UInt32[dst_addresses_rtb.Lines.Length];
			rtextbox_results.Text = "";
			byte[] hex_array;
			results = new CalcTable[dst_addresses_rtb.Lines.Length];

			if (crc_initial_value_textbox.Text.Length != 8)
			{
				rtextbox_results.Text += "ERROR: CRC Initial Value field needs to be 8 Characters in Length!\r\n";
				rtextbox_results.Text += "ERROR: Only numbers 0-9, characters a-f or A-F are valid!\r\n";
				error = true;
			}
			else if(String_Is_HEX_Compilant(crc_initial_value_textbox.Text))
			{
				rtextbox_results.Text += "ERROR: CRC Initial Value field needs to be VALID HEX data!\r\n";
				rtextbox_results.Text += "ERROR: Only numbers 0-9, characters a-f or A-F are valid!\r\n";
				error = true;
			}
			else
			{
				hex_array = new byte[4] { 0, 0, 0, 0 };
				hex_array = ConvertHexStringToByteArray(crc_initial_value_textbox.Text);

				crc_initial_value = (UInt32)hex_array[3];
				crc_initial_value += (UInt32)(hex_array[2] << 8);
				crc_initial_value += (UInt32)(hex_array[1] << 16);
				crc_initial_value += (UInt32)(hex_array[0] << 24);

			}

			if (polynomial_textbox.Text.Length != 8)
			{
				rtextbox_results.Text += "ERROR: CRC Polynomial Value field needs to be 8 Characters in Length!\r\n";
				rtextbox_results.Text += "ERROR: Only numbers 0-9, characters a-f or A-F are valid!\r\n";
				error = true;
			}
			else if (String_Is_HEX_Compilant(polynomial_textbox.Text))
			{
				rtextbox_results.Text += "ERROR: CRC Polynomial Value field needs to be VALID HEX data!\r\n";
				rtextbox_results.Text += "ERROR: Only numbers 0-9, characters a-f or A-F are valid!\r\n";
				error = true;
			}
			else
			{
				hex_array = new byte[4] { 0, 0, 0, 0 };
				hex_array = ConvertHexStringToByteArray(polynomial_textbox.Text);

				polynomial = (UInt32)hex_array[3];
				polynomial += (UInt32)(hex_array[2] << 8);
				polynomial += (UInt32)(hex_array[1] << 16);
				polynomial += (UInt32)(hex_array[0] << 24);
			}

			for (byte b = 0; b < dst_addresses_rtb.Lines.Length; b++)
			{
				if(dst_addresses_rtb.Lines[b].Length != 12)
				{
					rtextbox_results.Text += "ERROR: Destination MAC Address[" + b.ToString() + "] field needs to be 12 characters long!\r\n";
					error = true;
				}
				else if(String_Is_HEX_Compilant(dst_addresses_rtb.Lines[b]))
				{
					rtextbox_results.Text += "ERROR: Destination MAC Address field needs to be VALID HEX data!\r\n";
					rtextbox_results.Text += "ERROR: Only numbers 0-9, characters a-f or A-F are valid!\r\n";
					error = true;
				}
			}


			if (!error)
			{
				rtextbox_results.Text += "CRC Polynomial = 0x" + polynomial.ToString("X08") + "\r\n";
				rtextbox_results.Text += "CRC Initial = 0x" + crc_initial_value.ToString("X08") + "\r\n";


				for (byte b = 0; b < dst_addresses_rtb.Lines.Length; b++)
				{
					mac_address = ConvertHexStringToByteArray(dst_addresses_rtb.Lines[b]);
					CalcHashTable(hash_table, mac_address, 1);
				}

				rtextbox_results.Text += "\r\nHash Table Complete Result\r\n";

				for (UInt16 h = 0; h < hash_table_size; h++)
				{
					rtextbox_results.Text += "EHT[" + h.ToString() + "] = 0x" + hash_table[h].ToString("X02") + ";\r\n";
				}

				Matches(results);
			}
		}

        private void dst_addresses_rtb_KeyPress(object sender, KeyPressEventArgs e)
        {
			handle_keystrokes(e);
		}

        private void crc_initial_value_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
			handle_keystrokes(e);
		}

        private void polynomial_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
			handle_keystrokes(e);
		}

        private void crc_initial_value_textbox_TextChanged(object sender, EventArgs e)
        {
			if(String_Is_HEX_Compilant(crc_initial_value_textbox.Text))
			{
				rtextbox_results.Text += "ERROR: CRC Initial Value field needs to be VALID HEX data!\r\n";
				rtextbox_results.Text += "ERROR: Only numbers 0-9, characters a-f or A-F are valid!\r\n";
				crc_initial_value_textbox.Text = "FFFFFFFF";
			}
		}
		
        private void polynomial_textbox_TextChanged(object sender, EventArgs e)
        {
			if (String_Is_HEX_Compilant(polynomial_textbox.Text))
			{
				rtextbox_results.Text += "ERROR: CRC Polynomial Value field needs to be VALID HEX data!\r\n";
				rtextbox_results.Text += "ERROR: Only numbers 0-9, characters a-f or A-F are valid!\r\n";
				polynomial_textbox.Text = "04C11DB7";
			}
		}
    }
}
