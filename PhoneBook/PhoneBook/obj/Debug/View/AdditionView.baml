   M S B A M L   `   `   `  ����D  @PhoneBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PhoneBook.ViewModelPhoneBook.ViewModel  5   	   %clr-namespace:PhoneBook	PhoneBook  5   	   !    PhoneBook.View.AdditionView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PhoneBook.ViewModel     5   	   &vmclr-namespace:PhoneBook     5   	   -   5          �Name$  AdditionWindow��5   	    � Title$ AdditionView��5
   	   $	��350��6   $	��300��6+    � WindowStartupLocation$ CenterScreen=�67    � 	Resources 5         PhoneBook.MyValueConverter   MyValueConverter��%   &	          5   
   6   5       � DataContext 5      +  %PhoneBook.ViewModel.AdditionViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��First Name:��6   $��15q�6+   �� 5      $��
Last Name:��6   $��15q�6*   �� 5      $��Phone Number:��6   $��15q�6-   �� 5       $��Address��6   $��15q�6'   �� 5!      $��Image��6   $��15q�6%   �� 5"      -   5        $��id��5"   *   $y�Hidden=�6   ��64   �� *Id+5#      �� 5%   
   $ Vertical=�6   $��1��6,   .+�5&      �� -   5        $��	firstName��5&   "   $��15q�6   6"   �� 5'      -   5        $��lastName��5'   "   $��15q�6   6"   �� 5(      -   5        $��phoneNumber��5(   "   $��15q�6   6"   �� 5)      -   5        $��address��5)   "   $��15q�6   6"   �� 5*      -   5        $��import��5*   !   $��15q�6   $��50��6/   $��50��6:   ��6F   �� *ImportImageCommand+.��5+      �� $��50��61   $��50��6<   ��6   �� *Image+6<   5,      �� 5-      -   5        $��image��5-   "   $��15q�6   $y�Hidden=�6/   ��6C   �� *Image+5.      �� 50   
   $��1��6   $��1��6!   $��15q�6.   $��Close��6:   ��6J   �� *CancleRecordCommand+��6r   ��  �� ElementName$ AdditionWindow���� 52   
   $��0��6   $��1��6!   $��15q�6.   $
��Save��6:   ��6I   �� *SaveRecordCommand+��53      `� 54      	 `� 	Converter#	 [  6   .1�55      �� 
 �� Path$

 Text�6   $ id��6*   �� 56      $

 Text�6   $ 	firstName��6*   �� 57      $

 Text�6   $ lastName��6*   �� 58      $

 Text�6   $ phoneNumber��6*   �� 59      $

 Text�6   $ address��6*   �� 5:      $

 Text�6   $ image��6*   5;      5=      5?      5@      