   M S B A M L   `   `   `  ����   CrossManager_WPF_GUI     CrossManager_WPF_GUI.Tekma   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     6x,http://schemas.microsoft.com/winfx/2006/xaml     � Title$  Tekma�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � WindowState$ 	Maximized=�.��� }�.  ����  �� ImageSource$ images/Tekma.jpg�� �� Opacity$
 0.40Q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� -   $��grpbx_stoparica��$��0��$��
Štoparica��}�. .���� -   $��stopWatchTxtBlck��$��Digital Readout UpRight)�$��Center=�$��Center=�$��48(�����  �� Path$
 Text��� -   $��grpbx_tekmovanje��$��1��$��Tekmovanje - skupina ��.���  � ColumnDefinitions �� �� $
��Auto �.+��� $��0��$��Tekmovalci v teku��.���� -   $��lst_tekmovalci_unfinished��$��5q�$��5q�	 �� View	 �� P��� $��Zaporedna številka��
 �� DisplayMemberBinding
 �� $ ID��� $	��Ime��
 �� $ 
First_name��� $��Priimek��
 �� $ 	Last_name��� $��Razred��
 �� $ Grade��� $��Leto rojstva��
 �� $ 
Birth_date��� $��1��$��Nadzor tekmovanja��.���  �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��Vnos tekmovalca:���� -   $��lbl_tekmovalecFinished��$��1��$
��Auto���� -   $��startButton��$��2��|�.  .��Začni tekmo skupine� $��2�� �� �� .+��� -   $��	btn_nazaj��$��0��|�.  .��Nazaj�� -   $��
btn_naprej��$��1��|�.  .��Naslednja skupina