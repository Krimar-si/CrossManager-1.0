   M S B A M L   `   `   `  ����  CrossManager_WPF_GUI"    CrossManager_WPF_GUI.PoTekmi   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      6x,http://schemas.microsoft.com/winfx/2006/xaml   5        � Title$  Po tekmi��5      $	��600��6   $	��800��6#    � WindowStartupLocation$ CenterScreen=�6/   .��5      � ��5   
   �� 5       �� ImageSource$ images/silhouette.jpg��6    �� Opacity$
 0.60Q�6=   6N    � RowDefinitions 5	   
   �� 5
      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5        $��lst_tekmovalci��5   u   $��0��6Q   $��5q�6^   $��5q�6i    �� View 5      �� 5      P�5      �� 5      $
��Čas��6)    �� DisplayMemberBinding 66   ��  �� Path$ RunTime��� 5      $��Zaporedna številka��6)    6E   �� $ ID��� 5      $��Startna skupina��6)    6B   �� $ Start_group��� 5      $	��Ime��6)    66   �� $ 
First_name��� 5      $��Priimek��6)    6:   �� $ 	Last_name��� 5      $
��Spol��6)    67   �� $ Gender��� 5      $��Razred��6)    69   �� $ Grade��� 5      $��Leto rojstva��6)    6?   �� $ 
Birth_date�5      5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5       6%   �� 5!      6%   �� 5"      6%   .+�5%      �� -   5        $��0��5%      .��6H   Shrani spremembe6Z   �� 5&      -   5        $��1��5&      .��6A   Tiskanje rezultatov6V   �� 5'      -   5        $��2��5'      .��6=   Izhod6D   5(      5*      5+      