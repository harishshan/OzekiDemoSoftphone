   M S B A M L   `   `   `  ����Q  MOzekiDemoSoftphoneWPF, Version=1.8.17.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:OzekiDemoSoftphoneWPF.GUI.Converters$OzekiDemoSoftphoneWPF.GUI.Converters  5   	   4    .OzekiDemoSoftphoneWPF.GUI.MessageSummaryWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Cconv2clr-namespace:OzekiDemoSoftphoneWPF.GUI.Converters     5   	     � Title$  Message Summary��5   	   $	��262��6!   $	��556��6.    � 
ResizeMode$ NoResize=�6:    � ShowInTaskbar .   � WindowStartupLocation$ CenterOwner=�6f    � WindowStyle$ 
ToolWindow=�6�    � DataContext 5   	   ��  �� RelativeSource �� *Self+ � 	Resources 5      F  @OzekiDemoSoftphoneWPF.GUI.Converters.MessageSummaryLineConverter   MessageSummaryLineConverter��%   &	          5   
   6+   5	      .��5
      � .+�5   
   � $
��Left=�66   $��	12,12,0,0q�6Q   $	��Top=�6d   $	��510��6|   $	��170��6�    6   �� *MessageSummary+ � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $	��337 �6#   �� 5      $	��15* �6#   	 � RowDefinitions	 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Message Account:��6   $��0��6/   $��0��6?   $
��Left=�6L   $��3q�6g   $��Center=�6r   �� 5      -   5        $��messageAccountTextBox��5   ^   $��1��6   $��23��6&   $
��Left=�62   $��3,3,0,3q�6M   $��Center=�6�   $	��238��6�   ��6{   �� 
 �� Path$
 MessageAccount� �� Mode$ OneWay=�6�   �� 5      $��Message Summary Lines:��6   $��1��65   $
��Left=�6B   $��3,3,0,0q�6]   $	��Top=�6n   �� 5      -   5        $ ��messageSummaryLinesListBox��5   �   $��1��6   $��1��6&   $��63��63   $
��Left=�6?   $��3,3,0,0q�6�   $	��Top=�6�   $	��325��6	  ��6Z   �� *MessageSummaryLines+ �� 	Converter# [  6	  �� 5      $��Message Waiting:��6   $��0��6/   $��2��6?   $
��Left=�6L   $��3q�6g   $��Center=�6r   �� 5      -   5        $��messageWaitingCheckBox��5   �   {�.  $��1��6Z   $��2��6j   $
��Left=�6w   $��3,3,0,3q�6�   $��Center=�6�   $��48��6�   ��6   �� $
 MessageWaiting�$ OneWay=�6�   �� 5      $��Optional Message Headers:��6   $��3��68   $
��Left=�6E   $��3,3,0,77q�6`   $��Center=�6r   �� 5      -   5        $#��optionalMessageHeadersListBox��5   �   $��1��6   $��3��6&   $��26��63   $
��Left=�6?   $��3,3,0,77q�6�   $��Center=�6�   $	��325��6�   ��6Z   �� *OptionalMessageHeaders+6�   5      �� 5    
   -   5        $��btnClose��5       $��Close��6!   $��23��61   $
��Left=�6=   $��228,188,0,0q�6X   $	��Top=�6n   $��75��6�   6�   5!      5"      