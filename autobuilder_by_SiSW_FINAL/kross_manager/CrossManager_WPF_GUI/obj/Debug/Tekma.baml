   M S B A M L   `   `   `  ����  CrossManager_WPF_GUI     CrossManager_WPF_GUI.Tekma   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      6x,http://schemas.microsoft.com/winfx/2006/xaml   5        � Title$  Tekma��5       � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$
 None=�68    � WindowState$ 	Maximized=�6K   .��5      � }�.  ��5   
   �� 5       �� ImageSource$ images/Tekma.jpg��6    �� Opacity$
 0.40Q�68   6I    � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5        $��grpbx_stoparica��5   3   $��0��6   $��
Štoparica��6    }�. .��5      �� -   5        $��stopWatchTxtBlck��5      $��Digital Readout UpRight)�6J   $��Center=�6o   $��Center=�6�   $��48(�6�   ��6,   ��  �� Path$
 Text�5      5      �� 5   
   -   5        $��grpbx_tekmovanje��5       $��1��6   $��Tekmovanje - skupina ��68   .��5      �  � ColumnDefinitions 5      �� 5      6)   �� 5      $
��Auto �6'   66   .+�5      �� $��0��6   $��Tekmovalci v teku��6+   .��5      �� -   5        $��lst_tekmovalci_unfinished��5   6   $��5q�6   $��5q�6*   	 �� View	 5      �� 5       P�5!   "   �� 5"   &   $��Zaporedna številka��65   
 �� DisplayMemberBinding
 6Q   �� $ ID��� 5#   &   $	��Ime��65   
 6B   �� $ 
First_name��� 5$   &   $��Priimek��65   
 6F   �� $ 	Last_name��� 5%   &   $��Razred��65   
 6E   �� $ Grade��� 5&   &   $��Leto rojstva��65   
 6K   �� $ 
Birth_date�5(      5*      5+      �� 5-      $��1��6   $��Nadzor tekmovanja��6+   .��5.      �  5/      �� 50      $
��Auto �6,   6<   �� 51      $
��Auto �6,   6<   �� 52      $��* �6,   69   .+�55      �� $��0��6    $��Vnos tekmovalca:��6-   �� 56      -   5        $��lbl_tekmovalecFinished��56   :   $��1��6    $
��Auto��6-   6:   �� 57      -   5        $��startButton��57   .   $��2��6!   |�.  .��6k   Začni tekmo skupine6�   58      59      5:      5<      � 5>   
   $��2��6    5?      �� 5@      6%   �� 5A      6%   .+�5D      �� -   5        $��	btn_nazaj��5D   %   $��0��6   |�.  .��6z   Nazaj6�   �� 5E      -   5        $��
btn_naprej��5E   %   $��1��6   |�.  .��6}   Naslednja skupina6�   5F      5H      5I      