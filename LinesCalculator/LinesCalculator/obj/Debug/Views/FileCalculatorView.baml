   M S B A M L   `   `   `  ����J  FLinesCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LinesCalculatorLinesCalculator  5      (    "LinesCalculator.FileCalculatorView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:LinesCalculator     5        � DataContext  5	      -  'LinesCalculator.FileCalculatorViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��2* �6   .+�5   
   �� $��File Calculator��6   $��0q�6*   $
��Left=�65   $	��Top=�6P   $��0��6h   $��15(�5      $��Italic$�6   �� 5   
   $
��Left=�6   $	��Top=�60   $��10q�6H    �� Orientation$ 
Horizontal=�6T   $��1��6m   .+�5      �� $��30��6   $	��490��6"   $��Center=�6/   $��5q�6J   $
��Left=�6U   $��20(�5       �� 
IsReadOnly . ��66   ��  �� Path$
 Path��� 5      $��	Load File��6   $��70��6)   $��30��64   $��5q�6@   ��6K   �� *LoadFileCommand+5      �� 5   
   $
��Left=�6   $	��Top=�60   $��10q�6H   $ 
Horizontal=�6T   $��2��6m   .+�5      �� $��30��6   $	��490��6$   $��Center=�61   $��5q�6L   $
��Left=�6W   $��20(�5      ��6$   �� $ Result��� 5       $��	Calculate��6   $��70��6)   $��30��64   $��5q�6@   ��6K   �� *CalculateCommand+5!      5#      5$      