   M S B A M L   `   `   `  ���� [  WSystem.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms   CrossManager_WPF_GUI(   "CrossManager_WPF_GUI.PripravaTekme   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     6x,http://schemas.microsoft.com/winfx/2006/xaml   NForms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     � Title$  Priprava tekme��$	��800��$	��800�� � WindowStartupLocation$ CenterScreen=�.��� ����  �� ImageSource$ images/Priprava.jpg�� �� Opacity$
 0.40Q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Podatki o tekmi��.��� $
��Left=� �� ��  � ColumnDefinitions �� $
��Auto �$��86���� .+��� $��5q�$
��Left=�$��-1,0,0,0q�$��85.79��.��
Ime tekme:�� -   $��txtbx_tekmaName��$��0��$��1��$��5q��� $��1��$��0��$��5q�.��Število skupin:7  1System.Windows.Forms.Integration.WindowsFormsHost  $��1��$��1��   Child. (   "System.Windows.Forms.NumericUpDown  -   nud_stSkupin���� $��2��$��
Tekmovalci��$��5q�.���  �� $
��Auto ��� $��* ��� $
��Auto �.+�� $��0��$��5q� �� $��* ��� $��* �.+��� -   $��0��$��5q�.��Dodaj novega tekmovalca�� $��1��$"��Uvoz/Izvoz iz *.csv datoteke��.���  �� ��  �� �� .+��� $��2��$��0�� �� Orientation$ 
Horizontal=�$��Center=�.+��� .��Ločilni znak:�� -   $��txtbx_csvSeparator��$��20��$��;�� �� 	MaxLength$ 1���� -   $��0��$��1��.��Uvozi tekmovalce�� -   $��1��$��1��.��Izvozi tekmovalce�� -   $��lst_tekmovalci��$��1��$��5q�$��5q�	 �� View	 �� P��� $��Zaporedna številka��
 �� DisplayMemberBinding
 ��  �� Path$ ID��� $��Startna skupina��
 �� $ Start_group��� $	��Ime��
 �� $ 
First_name��� $��Priimek��
 �� $ 	Last_name��� $
��Spol��
 �� $ Gender��� $��Razred��
 �� $ Grade��� $��Leto rojstva��
 �� $ 
Birth_date� � ToolTip$[ UZa urejanje dvokliknite tekmovalca. Za izbris izbranega tekmovalca pritisnite DELETE.��� $��2�� �� �� .+��� -   $��0��$��2q�$��2q�.��Shrani tekmo kot...�� $��1��$��Right=�$ 
Horizontal=�.+��� .��Število tekmovalcev:�� ����  �� ElementName$ lst_tekmovalci��$ Items.Count�� $��3��$��5q� �� $
��Auto ��� $
��Auto ��� $��* �$	��121��.+��� -	   $��nacinTiskaImen��$��0��$&�� Izbira tiskanja imen tekmovalcev��$��5q�$��5q�.���  �� ��  �� �� .+�	� -
   $��_3x2xA4��$��0��$��0�� d� 	IsChecked$
 TrueY�$��3q�.���� $��images/_3x2xA4.jpg��$��50�� �� $��images/_3x2xA4.jpg��	� -   $��_2xA4��$��0��$��1��$��3q�.���� $��images/_2xA4.jpg��$��50�� �� $��images/_2xA4.jpg��	� -   $��_1xA4��$��1��$��0��$��3q�.���� $��images/_1xA4.jpg��$��50�� �� $��images/_1xA4.jpg��	� -   $��_2x2xA4��$��1��$��1��$��3q�.���� $��images/_2x2xA4.jpg��$��50�� �� $��images/_2x2xA4.jpg���� -   $��tiskanjeKod��$��1��$!��Izbira tiskanja črtnih kod��$��5q�$��5q�.���� $ Vertical=�.+�	� -   $	��_DA��$
 TrueY�$��3q�.��S črtnimi kodami	� -   $	��_NE��$��3q�.��Brez črtnih kod�� -   $��2��$��5q�$��5q�.��Izvozi tekmovalne kartone� $��4��$��5q� �� �� .+��� -   $��0��$��5q�$��5q�.��Nazaj�� -   $��1��$��5q�$��5q�.��Začni tekmo