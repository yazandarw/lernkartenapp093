   M S B A M L   `   `   `  ����  
Ui.Desktop<    6De.HsFlensburg.ClientApp093.Ui.Desktop.PdfExportWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � WindowState$  Normal=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�64    � Title$ PDFExportWindow��5   	   $	��450��6!   $	��800��6.    � DataContext 5	      �� 5
   
      	VMLocator �� Source# [  6    �� Path$ PDFExportVM�5      6'   .��5      � ���	#FFF4F4F4 � ColumnDefinitions 5   
   �� 5      $	��100 �6   6-   �� 5      $��2* �6   6,   �� 5      $	��100 �6   6-    � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $	��220 �6   6+   �� 5      6   .+�5   
   �� $��3��6   ���#6e9cb55      �� 5   
   $��3��6   $��/Images/TXT.png��5      $	��400��5      �� 5   
   $��Center=�6   $��Center=�5       $��60��5!      $��/Images/pdf.png��5"      �� 5#   
   $��1��6   $��1��5$      $
��Bold"�5%      ���#166088$��15 15q�5'      $��16(�5(      .��6   64Please choose one or multiple cards to export as PDF5*      �� 5+   
   $��1��5,      $��1��5-      $��20,45,20,10q�5.      	 �� SelectionMode$	 Multiple=�5/      ��50      �� $ SelectedCardsList�
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���51      �� 52       �� 
TargetType" ��6   .�53      ��  �� Property �@��
IsSelected �� Value 63   �� *
IsSelected+54      ��56      �� 57      .R�58      �� .+�59      �� ��5:      �� *Name+5;      5<      5=      5?      �� 5@   
   $��2��6   $��1��5A      $	��Top=�5B      $��Center=�5C       �� Orientation$ 
Horizontal=�5D      $
��20,0q�5E      .+�5F      	� $��With Answers��5G       d� 	IsChecked 5F      �� *IsWithAnswers+$
 TwoWay=�$ PropertyChanged=�5G      	� 5H      $��20,0,0,0q�5I      $��Without Answers��5J       5H      �� *IsWithoutAnswers+$
 TwoWay=�$ PropertyChanged=�5J      5K      �� 5L   
   $��1��6   $��2��5M      $��35��5N      $	��150��5O      $��16(�5P      $��Center=�5Q      $��Center=�5R        btn2#��[ 5S      ��5T      �� *ExportAsPDF+$
 TwoWay=�$ PropertyChanged=�.��6c   Save as PDF5V      5W      5X      