   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5      "    WpfApp1.WPFPlayerUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5      -   5        
�������  �� ClearTypeHint$  Enabled=�5	   C    � 	Resources 5      "   WpfApp1.WPFPlayerUserControl �� 
TargetType �� Triggers :� RoutedEvent �� TargetProperty	 �� To g� Duration �� Property	 �� Value
 �� 
TargetType �� CornerRadius��%�  '        �� 5   
   "  6    5      :� 5      $ 
MouseEnter��6   .[�5      �� .��5      �� .��5      �� $* $(Background).(SolidColorBrush.Color)�6-    	LightBlue5   1   $ 0:0:0.3D�6@   5      5      5      :� 5      $ 
MouseLeave��6   .[�5      �� .��5      �� .��5      �� $* $(Background).(SolidColorBrush.Color)�6-   	 White5   1   $ 0:0:0.3D�6<   5      5       5!      .�5$      ��  � ��	 5%      �� 5&      "
  6&   .R�5'      �� #��z��6!   #��z��5(   !   #��z��5)   !   $ 5��5*   !   ._�5+      �� 5/      50      52      56      5:      .��5?      �  � ColumnDefinitions 5@   
   �� 5A      $��1* �6    � RowDefinitions 5C   
   �� 5D      $��50 �6   �� 5E      $��1* �6   �� 5F      $��1* �6   �� 5G      $��1* �6   .+�5I   
   �� -   5         ��Name$ imgPlayerImage��5I   �   $��1��6   $��1��6$   $��0��65   $��0��6E   $��Uniform=�6R   $��Center=�6d   $
��auto��6�   $	��Top=�6�   $
��auto��6�   $��/Default_image.png��6�   �� 5K   
   -   5         ��Name$ lblNameSurname��5K   �   $��Name Surname��6   $��0��6'   $��1��67   $��Center=�6D   $	��Top=�6a   $��11(�6y   $��0q�6�   6�   �� 5L   
   -   5        $ lblName��5L   �   $
��Name��6   $y�Hidden=�6   $��0��63   $��1��6C   $
��Left=�6P   $	��Top=�6k   $��12(�6�   $��0q�6�   6�   �� 5M   
   -   5        $ 
lblSurname��5M   �   $��Surname��6   $y�Hidden=�6"   $��0��66   $��1��6F   $��Right=�6S   $	��Top=�6o   $��12(�6�   $��0q�6�   6�   �� 5N   
   -   5        $ 	lblNumber��5N   �   $��Number��6   $��0��6!   $��2��61   $��Center=�6>   $	��Top=�6[   $��14(�6s   $��0q�6�   6�   �� 5O   
   -   5        $ lblPosition��5O   �   $��Position��6   $��0��6#   $��3��63   $��Center=�6@   $	��Top=�6]   $��12(�6u   $��0q�6�   6�   5X      5Y      