   M S B A M L   `   `   `  ����   
Ui.Desktop<    6De.HsFlensburg.ClientApp093.Ui.Desktop.PdfExportWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � WindowState$  Normal=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � Title$ PDFExportWindow��$	��450��$	��800�� � DataContext ��    	VMLocator �� Source# [   �� Path$ PDFExportVM�.��� ���	#FFF4F4F4 � ColumnDefinitions �� $	��100 ��� $��2* ��� $	��100 � � RowDefinitions �� $��80 ��� $	��220 ��� .+��� $��3�����#6e9cb5�� $��3��$��/Images/TXT.png��$	��400���� $��Center=�$��Center=�$��60��$��/Images/pdf.png���� $��1��$��1��$
��Bold"����#166088$��15 15q�$��16(�.��64Please choose one or multiple cards to export as PDF�� $��1��$��1��$��20,45,20,10q�	 �� SelectionMode$	 Multiple=����� $ SelectedCardsList�
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�����  �� 
TargetType" ��.���  �� Property �@��
IsSelected �� Value �� *
IsSelected+���� .R��� .+��� ���� *Name+�� $��2��$��1��$	��Top=�$��Center=� �� Orientation$ 
Horizontal=�$
��20,0q�.+�	� $��With Answers�� d� 	IsChecked �� *IsWithAnswers+$
 TwoWay=�$ PropertyChanged=�	� $��20,0,0,0q�$��Without Answers�� �� *IsWithoutAnswers+$
 TwoWay=�$ PropertyChanged=��� $��1��$��2��$��35��$	��150��$��16(�$��Center=�$��Center=�  btn2#��[ ���� *ExportAsPDF+$
 TwoWay=�$ PropertyChanged=�.��Save as PDF