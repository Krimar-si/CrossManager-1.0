   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5       CrossManager_WPF_GUI#   CrossManager_WPF_GUI.VecTekem   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      6x,http://schemas.microsoft.com/winfx/2006/xaml   5      NForms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms   5        � Title$  
Več tekem��5      $	��200��6   $	��400��6$    � WindowStartupLocation$ CenterScreen=�60   .��5      � ��5   
   �� 5       �� ImageSource$ images/runners.jpg��6    �� Opacity$
 0.60Q�6:   6K    � RowDefinitions 5
   
   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   �� $��Center=�6   $��Center=�60   .+�5      �� $��2q�6   $
��Left=�6    .��6;   Ime združene tekme:6P   �� 5      -   5        $��txtbx_tekmaName��5      $��2q�6-   6;   �� 5      .��6   +)Število tekem, ki jih želite združiti:6<   7  1System.Windows.Forms.Integration.WindowsFormsHost  5      $��0��6   $��1��6/      Child. 5      (   "System.Windows.Forms.NumericUpDown     Minimum$ 2~�6&      Maximum$	 100~�62   -   5        stZdruzitev��5   W   5      5      � 5   
   $��1��6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5        $��0��5      .��66   	Združi6>   �� 5    
   -   5        $��1��5       .��68   	Prekliči6B   5!      5"      5#      