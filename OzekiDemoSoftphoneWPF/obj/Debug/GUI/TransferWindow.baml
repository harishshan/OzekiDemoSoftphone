   M S B A M L   `   `   `  ����Q  MOzekiDemoSoftphoneWPF, Version=1.8.17.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:OzekiDemoSoftphoneWPF.GUI.Converters$OzekiDemoSoftphoneWPF.GUI.Converters  5   	   .    (OzekiDemoSoftphoneWPF.GUI.TransferWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Cconv2clr-namespace:OzekiDemoSoftphoneWPF.GUI.Converters     5   	     � Title$  Transfer Call��5   	   $	��287��6   $	��300��6,    � WindowStartupLocation$ CenterOwner=�68    � WindowStyle$ 
ToolWindow=�6\    � 
ResizeMode$ NoResize=�6u    � ShowInTaskbar .   � DataContext 5   	   ��  �� RelativeSource �� *Self+ � 	Resources 5      H  BOzekiDemoSoftphoneWPF.GUI.Converters.TransferModeToBTBoolConverter !  TransferModeToBTBoolConverterH  BOzekiDemoSoftphoneWPF.GUI.Converters.TransferModeToATBoolConverter ! TransferModeToATBoolConverterN  HOzekiDemoSoftphoneWPF.GUI.Converters.AttendedTransferTargetListConverter ' #AttendedTransferTargetListConverter��%W   &	        &	      &	 &       5   
   6-     5	   
   6-     5
   
   63   5      .��5      � .+�5   
   �� -   5        $��rectBlindTransfer��5       $��87��6   
���   �$	��Top=�6H   $��6,6,6,0q�6`   $��2��6q   	� 5   
   -   5        $��rbBlindTransfer��5      $��Blind Transfer��6-   $��16��6F   $
��Left=�6R   $��	12,12,0,0q�6m   $	��Top=�6�    d� 	IsChecked 6�   �� *Model.TransferMode+	 �� 	Converter#	 [  � 5   
   $��	6,6,6,155q�6Q   {�6   �� 
 �� ElementName$
 rbBlindTransfer�� �� Path$ 	IsChecked� � ColumnDefinitions 5      �� 5      $��60 �6#   �� 5      $
��213* �6#   .+�5      �� -   5        $��lBlindTransferTarget��5      $��Target:��60   $��28��6B   $
��Left=�6N   $��	18,36,0,0q�6i   $	��Top=�6}   �� 5      -   5        $��lExample��5      $'��!Example: 873 or 873@192.168.112.1��6$   $��28��6P   $
��Left=�6\   $��	17,62,0,0q�6w   $	��Top=�6�   $��Italic$�6�   $��11(�6�   $��1��6�   �� 5      -   5        $��tbBlindTransferTarget��5      $��23��6^   $
��Left=�6j   $��0,36,0,0q�6�   $	��Top=�6�   $	��195��6�   $��1��6�   ��63   �� *Model.BlindTransferTarget+6�   5      �� 5   
   -   5        $��rectAttendedTransfer��5   !   $	��104��6   
���   �$	��Top=�6L   $��6,99,6,0q�6d   $��2��6v   	� 5   
   -   5        $��rbAttendedTransfer��5      $��Attended Transfer��60   $��16��6L   $
��Left=�6X   $��
12,107,0,0q�6s   $	��Top=�6�    6�   �� *Model.TransferMode+#	 [ � 5   
   $��	6,99,6,45q�6T   {�6   �� $
 rbAttendedTransfer��$ 	IsChecked� 5      �� 5      $��60 �6#   �� 5      $
��213* �6#   .+�5"      �� -   5        $��lAttendedTransferText��5"      $K��EPlease select the other call where want to transfer the current call.��66   $��32��6�   $
��Left=�6�   $��	18,30,0,0q�6�   $	��Top=�6�   $��2��6�   $	��242��6�   $
��Wrap=�6�   $��11(�6	  $��Italic$�6  �� 5#      -	   5        $��lAttendedTransferTarget��5#      $��Target:��63   $��28��6E   $
��Left=�6Q   $��	18,68,0,0q�6l   $	��Top=�6�   �� 5$      -
   5        $��cbAttendedTransferTarget��5$       �� DisplayMemberPath$ DialInfo��67   $��1��6�   $��23��6�   $
��Left=�6�   $��0,68,0,0q�6�   $	��Top=�6�   $	��195��6�    �� SelectedItem 6T   �� *Model.AttendedTransferTarget+��5%      `� 5&       `� 	Converter# [ 6#   .1�5'      �� $ Model.PhoneCalls�6"    �� Mode$ OneWay=�6:   �� 5(      $ Model.Transferee�6"   $ OneWay=�6:   5)      5+      5,      �� 5-   
   -   5        $��btnBlindTransfer��5-      $��Transfer��6)   $��23��6<   $
��Left=�6H   $��
66,213,0,0q�6c   $	��Top=�6x   $��75��6�   6�   �� 5.   
   -   5        $��	btnCancel��5.      $��Cancel��6"   $��23��63   $
��Left=�6?   $��147,213,0,0q�6Z   $	��Top=�6o   $��75��6�   6�   5/      50      