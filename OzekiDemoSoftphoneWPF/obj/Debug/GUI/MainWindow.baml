   M S B A M L   `   `   `  ����Q  MOzekiDemoSoftphoneWPF, Version=1.8.17.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:OzekiDemoSoftphoneWPF.GUI.Converters$OzekiDemoSoftphoneWPF.GUI.Converters  5   	   P LOzekiSDK, Version=1.8.18.0, Culture=neutral, PublicKeyToken=4812fb35129b8487;+clr-namespace:Ozeki.Media;assembly=OzekiSDKOzeki.Media 5   	   I)clr-namespace:OzekiDemoSoftphoneWPF.ModelOzekiDemoSoftphoneWPF.Model  5   	   *    $OzekiDemoSoftphoneWPF.GUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Cconv2clr-namespace:OzekiDemoSoftphoneWPF.GUI.Converters     5   	   =video+clr-namespace:Ozeki.Media;assembly=OzekiSDK     5   	   ;Model)clr-namespace:OzekiDemoSoftphoneWPF.Model     5   	   -   5        $��647.063��5   _   $	��986��6p     � WindowStartupLocation$  CenterScreen=�6|    � Icon$= 7/OzekiDemoSoftphoneWPF;component/Resources/sdk_icon.ico��5   v    � 
ResizeMode$ CanMinimize=�6�    � Title 5   A   �� *TitleString+ � DataContext 5   	   ��  �� RelativeSource �� *Self+ � 	Resources 5      F  @OzekiDemoSoftphoneWPF.GUI.Converters.SIPAccountToStringConverter   SIPAccountToStringConverterG  AOzekiDemoSoftphoneWPF.GUI.Converters.IncomingToDirectionConverter   IncomingToDirectionConverterJ  DOzekiDemoSoftphoneWPF.GUI.Converters.MessageSummaryToStringConverter # MessageSummaryToStringConverterH  BOzekiDemoSoftphoneWPF.GUI.Converters.MessageSummaryToBoolConverter ! MessageSummaryToBoolConverterG  AOzekiDemoSoftphoneWPF.GUI.Converters.FileNameToIsEnabledConverter   FileNameToIsEnabledConverter>  8OzekiDemoSoftphoneWPF.GUI.Converters.ResolutionConverter  ResolutionConverterB  <OzekiDemoSoftphoneWPF.GUI.Converters.ResolutionListConverter  ResolutionListConverterE  ?OzekiDemoSoftphoneWPF.GUI.Converters.FrameRateToStringConverter  FrameRateToStringConverterI	  COzekiDemoSoftphoneWPF.GUI.Converters.FrameRateListToStringConverter " FrameRateListToStringConverterD
  >OzekiDemoSoftphoneWPF.GUI.Converters.RingtoneToStringConverter 	 RingtoneToStringConverterQ  KOzekiDemoSoftphoneWPF.GUI.Converters.SupportedMediaTypesToCallTypeConverter *
 &SupportedMediaTypesToCallTypeConverter  CodecPanelTemplate � 	ItemWidth �� AncestorType	 � 
ItemHeight��%Y  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     &	 �       5	   
   6+     5
   
   6,     5   
   6/     5   
   6-     5   
   6,     5   
   6#     5   
   6'     5   
   6*   	  5   
   6.   
  5   
   6)     5   
   66   �� 5   
   .R�5      � $ 80��5   $   ��5      �� * (FrameworkElement.ActualWidth)+ �� $ ScrollContentPresenterL���5   $   �� *	ItemWidth+ �� *Self+	 5   $   �� *(ListView.View).ItemHeight+ �� $ ListViewL�5      5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $��41 �6   5      �� 5      $��* �6   6)    � ColumnDefinitions 5!   
   �� 5"      $��6 �6   �� 5#      $	��760 �6   �� 5$      $
��208* �6   .+�5&   
   �� -   5        $��lOzekiVoIPSIPSDK��5&      $��Ozeki VoIP SIP SDK��6(   $
��Left=�6F   $��6,7,0,0q�6a   $	��Top=�6r   $��18(�6�   $
��Bold"�6�   $��1��6�   $��33.94��6�   $��214.75��6�   �� 5'   
   -   5        $��btnAboutOzeki��5'      $��About Ozeki��6&   $��23��6<   $��
631,12,0,0q�6H   $	��Top=�6\   
����iA�
�������$��1��6�   $
��Left=�6�   $��82��6�   �� 5(   
   -   5        $��btnProjects��5(      $��Projects��6$   $��23��67   $
��Left=�6C   $��
718,12,0,0q�6^   $	��Top=�6s   $��75��6�   $��1��6�   $��2��6�   �� 5)   
   -   5        $��
btnWebsite��5)      $��Website��6#   $��23��65   $
��Left=�6A   $��	38,12,0,0q�6\   $	��Top=�6p   $��75��6�   $��2��6�   �� 5*   
   -   5        $��btnHelp��5*      $
��Help��6    $��23��6/   $��
118,12,0,0q�6;   $	��Top=�6P   $��2��6~   $
��Left=�6�   $��75��6�   �� 5+   
   $��1��6   $��3��6"   .@�5,      �� $��	Softphone��6   .��5-      �  5.      �� 5/      $��6 �6+   �� 50      $	��760 �6+   �� 51      $
��208* �6+   
 53      �� 54      $��0 �6(   �� 55      $	��116 �6(   �� 56      $��6 �6(   �� 57      $	��203 �6(   �� 58      $��6 �6(   �� 59      .+�5<      �� -   5        $��grpRemoteVideo��5<      $��Remote video��65   $	��164��6K   $
��Left=�6X   $	��Top=�6s   $��2��6�   $��3��6�   $��0,0,0,0q�6�   $	��196��6�   .��5=      � .+�5>         Ozeki.Media.VideoViewerWPF  -   5        $��remoteVideoViewer��5>   x   $	��180��63   $	��135��6?   $
��Left=�6L   $��4,7,0,0q�6g   $	��Top=�6�   $��2��6�   5?      5@      �� 5A      -	   5        $��tabControl1��5A   \   $	��198��6!   $
��Left=�6.   $��	180,0,0,0q�6I   $	��Top=�6o   $	��574��6�   $��3��6�   $��1��6�   .@�5B      �� -
   5        $��tiPhoneCalls��5B   8   $��Active Calls��6"   .��5C      � .+�5D   "   �� -   5        $��lvPhoneCalls��5D   +   $	��1,0q�6�   $��136.04��6�   $	��Top=�6�   ��6?   �� *Model.PhoneCalls+ �� SelectedItem 6h   �� *Model.SelectedCall+ �� View 5E   &   �� 5F   *   .P�5G   .   ��  �� Width$	 180��6=   $��
Phone Line��6I    �� DisplayMemberBinding 6]   �� *PhoneLine.SIPAccount+ �� 	Converter# [  �� 5H   .   $	 180��6=   $��Other Party��6I    6^   �� *
OtherParty+�� 5I   .   $ 55��6=   $��	Direction��6H    6[   �� *
IsIncoming+# [ �� 5J   .   $	 130��6=   $��
Call State��6I    6]   �� *ReasonOfState+5K   +   5M   #   �� 5N   "   -   5        $��	btnAnswer��5N   )   $��Answer��6:   $��23��6K   $
��Left=�6W   $	��Top=�6r   $��63��6�   $��1,141.04,0,0q�6�   6�   �� 5O   "   -   5        $��	btnReject��5O   )   $��Reject��6:   $��23��6K   $
��Left=�6W   $	��Top=�6r   $��63��6�   $��69,141.04,0,0q�6�   6�   �� 5P   "   -   5        $��	btnHangup��5P   )   $��Hang up��6:   $��23��6L   $
��Left=�6X   $	��Top=�6s   $��63��6�   $��137,141.04,0,0q�6�   6�   �� 5Q   "   -   5        $��btnHold��5Q   )   $
��Hold��68   $��23��6G   $
��Left=�6S   $	��Top=�6n   $��63��6�   $��205,141.04,0,0q�6�   �� 5R   "   -   5        $��	btnUnhold��5R   )   $��Unhold��6:   $��23��6K   $
��Left=�6W   $	��Top=�6r   $��63��6�   $��273,141.04,0,0q�6�   6�   �� 5S   "   -   5        $��
btnForward��5S   )   $��Forward��6;   $��23��6M   $
��Left=�6Y   $	��Top=�6t   $��63��6�   $��409,141.04,0,0q�6�   6�   �� 5T   "   -   5        $��btnTransfer��5T   )   $��Transfer��6<   $��23��6O   $
��Left=�6[   $	��Top=�6v   $��63��6�   $��341,141.04,0,0q�6�   6�   �� 5U   "   -   5        $��cbAudioVideoCall��5U   +   $��23��6!  $
��Left=�6-  $��477,141.04,0,0q�6H  $	��Top=�6`  $��83��6x  ��6C   �� *Model.CallTypes+ �� Mode$ OneWay=� 6x   ��  �� ElementName$ lvPhoneCalls�� �� Path$&  SelectedItem.SupportedMediaTypes�$ OneWay=�# [
 6�  5V      5W      �� 5X      -   5        $��tiCallHistory��5X   8   $��Call History��6"   .��5Y      � .+�5Z   "   �� -   5        $��lvCallHistory��5Z   +   $��1,0,7,0q�6o   $	��136��6�   $	��Top=�6�   ��6@   �� *Model.CallHistory.List+ 5[   &   �� 5\   *   .P�5]   .   �� $	 180��6=   $��
Phone Line��6I    6]   �� *	PhoneLine+�� 5^   .   $	 180��6=   $��Other Party��6I    6^   �� *
OtherParty+�� 5_   .   $ 55��6=   $��	Direction��6H    6[   �� *
IsIncoming+# [ �� 5`   .   $	 130��6=   $��
Call State��6I    6]   �� *ReasonOfState+5a   +   5c   #   �� 5d   "   -   5        $��	btnRedial��5d   )   $��Redial��6:   $��23��6K   $
��Left=�6W   $��	1,141,0,0q�6r   $	��Top=�6�   $��63��6�   6�   �� 5e   "   -   5        $��btnClearCallHistory��5e   )   $��Clear history��6D   $��23��6\   $
��Left=�6h   $��
69,141,0,0q�6�   $	��Top=�6�   $��81��6�   6�   5f      5g      �� 5h      -   5        $��
tiMessages��5h   4   $��Messages��6"   .��5i      � .+�5j   "   �� -   5        $��btnClear��5j   9   $��Clear��6)   $
��Left=�6I   $��479,107.08,0,0q�6d   $	��Top=�6|   $��75��6�   6�   �� 5k   "   -   5        $��btnSend��5k   8   $
��Send��6)   $
��Left=�6G   $��479,134.08,0,0q�6b   $	��Top=�6z   $��75��6�   6�   �� 5l   "   $��101.08��6*   $��1,0,7,0q�6:   $	��Top=�6K   ��6c   �� *Model.InstantMessages+�� 5m   "   $	��To:��6(   $
��Left=�66   $��4.083,106.08,0,0q�6Q   $	��Top=�6k   �� 5n   "   $
��Left=�6*   $��23��6E   $��68.373,107.08,0,0q�6Q    �� TextWrapping$
 Wrap=�6l   $	��Top=�6�   $	��130��6�   ��6�   �� *	Recipient+6�   �� 5o   "   $��Message:��6(   $
��Left=�6;   $��4.083,133.08,0,0q�6V   $	��Top=�6p   �� 5p   "   $
��Left=�6*   $��23��6E   $��68.373,135.08,0,0q�6Q   $
 Wrap=�6l   $	��Top=�6�   $��405.627��6�   ��6�   �� *InstantMessage+6�   5q      5r      5s      �� 5t      -   5        $��
grpDialPad��5t   X   $��Dialpad��6   $	��198��60   $
��Left=�6=   $	��Top=�6j   $	��177��6�   $��3��6�   $��1��6�   .��5u      � 
 5v      �� 5w   "   $��30 �60   �� 5x   "   $��25 �60   �� 5y   "   $��25 �60   �� 5z   "   $��25 �60   �� 5{   "   $��25 �60   �� 5|   "   $	��25* �60    5~      �� 5   "   $��55 �63   �� 5�   "   $��55 �63   �� 5�   "   $��55 �63   �� 5�   "   $��70 �63   �� 5�   "   $
��101* �63   .+�5�      �� -   5        $��tbDial��5�   &   $
��Left=�6P   $	��Top=�6l   $	��158��6�   $��2,5,0,0q�6�   $��Right=�6�   $��3��6�   ��64   �� *
DialNumber+6�   �� 5�      -   5        $��btnDialAudio��5�   %   $��Dial (A)��69    � ToolTip$* $Make a call using only audio channel��6L   $��1��6{   $��23��6�   $
��Left=�6�   $	��Top=�6�   $��50��6�   6�   �� 5�      -   5        $��btnDialVideo��5�   %   $��Dial (V)��69   $0 *Make a call using audio and video channels��6L   $��1��6�   $��1��6�   $��23��6�   $
��Left=�6�   $	��Top=�6�   $��50��6�   6�   �� 5�      -   5        $��btnDialPadIP��5�   %   $��	Dial (IP)��69   $+ %Make a call directly to an IP address��6M   $��1��6}   $��2��6�   $��23��6�   $
��Left=�6�   $	��Top=�6�   $��50��6�   6�   �� 5�      -    5        $��btnKey1��5�   %   $��1��64   
 � Tag$ 1��6@   $��2��6H   $��0��6U   $��23��6e   $
��Left=�6q   $	��Top=�6�   $��50��6�   $��14(�6�   $
��Bold"�6�   6
  �� 5�      -!   5        $��btnKey2��5�   %   $��2��64   $ 2��6@   $��2��6H   $��1��6U   $��23��6e   $
��Left=�6q   $	��Top=�6�   $��50��6�   $��14(�6�   $
��Bold"�6�   6
  �� 5�      -"   5        $��btnKey3��5�   %   $��3��64   $ 3��6@   $��2��6H   $��2��6U   $��23��6e   $
��Left=�6q   $	��Top=�6�   $��50��6�   $��14(�6�   $
��Bold"�6�   6
  �� 5�      -#   5        $��btnKey4��5�   %   $��4��64   $ 4��6@   $��3��6H   $��0��6U   $��23��6e   $
��Left=�6q   $	��Top=�6�   $��50��6�   $��14(�6�   $
��Bold"�6�   6
  �� 5�      -$   5        $��btnKey5��5�   %   $��5��64   $ 5��6@   $��3��6H   $��1��6U   $��23��6e   $
��Left=�6q   $	��Top=�6�   $��50��6�   $��14(�6�   $
��Bold"�6�   6
  �� 5�      -%   5        $��btnKey6��5�   %   $��6��64   $ 6��6@   $��3��6H   $��2��6U   $��23��6e   $
��Left=�6q   $	��Top=�6�   $��50��6�   $��14(�6�   $
��Bold"�6�   6
  �� 5�      -&   5        $��btnKey7��5�   %   $��7��64   $ 7��6@   $��4��6H   $��0��6U   $��23��6e   $
��Left=�6q   $	��Top=�6�   $��50��6�   $��14(�6�   $
��Bold"�6�   6
  �� 5�      -'   5        $��btnKey8��5�   %   $��8��64   $ 8��6@   $��4��6H   $��1��6U   $��23��6e   $
��Left=�6q   $	��Top=�6�   $��50��6�   $��14(�6�   $
��Bold"�6�   6
  �� 5�      -(   5        $��btnKey9��5�   %   $��9��64   $ 9��6@   $��4��6H   $��2��6U   $��23��6e   $
��Left=�6q   $	��Top=�6�   $��50��6�   $��14(�6�   $
��Bold"�6�   6
  �� 5�      -)   5        $��
btnKeyStar��5�   %   $��*��67   $ 10��6C   $��5��6L   $��0��6Y   $��23��6i   $
��Left=�6u   $	��Top=�6�   $��50��6�   $��14(�6�   $
��Bold"�6�   6  �� 5�      -*   5        $��btnKey0��5�   %   $��0��64   $ 0��6@   $��5��6H   $��1��6U   $��23��6e   $
��Left=�6q   $	��Top=�6�   $��50��6�   $��14(�6�   $
��Bold"�6�   6
  �� 5�      -+   5        $��
btnKeyHash��5�   %   $��#��67   $ 11��6C   $��5��6L   $��2��6Y   $��23��6i   $
��Left=�6u   $	��Top=�6�   $��50��6�   $��14(�6�   $
��Bold"�6�   6  5�      5�      �� 5�      -,   5        $��grpPhoneLine��5�      $��Phone line settings��63   $
��Left=�6P   $	��323��6l   $��1��6x   $��1��6�   $��	431,0,0,5q�6�   .��5�      �  5�      �� 5�   "   $	��118 �63   �� 5�   "   $	��182 �63   �� 5�   "   
 5�      �� 5�   "   $��8 �60   �� 5�   "   $��26 �60   �� 5�   "   $��26 �60   �� 5�   "   $��26 �60   �� 5�   "   $��26 �60   �� 5�   "   $��7* �60   .+�5�      �� --   5        $��chkbAutoAnswer��5�   '   $��Auto-answer��6=   $��1��6�   $��3��6�   $��16��6�   $
��Left=�6�   $��Center=�6   d� 	IsChecked 6S   �� $ cbPhoneLines��$ SelectedItem.AutoAnswer�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6  �� 5�      -.   5        $��chkbDoNotDisturb��5�   '   $	��DND��6?   $��1��6�   $��3��6�   $��16��6�   $
��Left=�6�   $��Center=�6  $��2��6-  $��100.601,5,-41.519,5q�6A   6M   �� $ cbPhoneLines��$ SelectedItem.DoNotDisturb�$ TwoWay=�$ PropertyChanged=�6A  �� 5�      $��1��6$   $��Keep-alive mode:��61   $��Right=�6L   $��Center=�6h   �� 5�      -/   5        $��cbKeepAlive��5�   '   $��1��6:   $��1��6J   $��23��6W   $
��Left=�6c   $��Center=�62  $	��100��6M  $��0,1.5q�6Y  ��6~   �� *KeepAliveValues+ 6�   �� $ cbPhoneLines��$' !SelectedItem.Config.KeepAliveMode�$ TwoWay=�$ PropertyChanged=�6Y  �� 5�      $��2��6$   $��Keep-alive interval:��61   $��Right=�6P   $��Center=�6l   �� 5�      -0   5        $��tbKeepAliveInterval��5�   &   $��1��6A   $��2��6Q   $
��Left=�6�   $��Center=�6  $��40��6  $��22��6'  $	��0,2q�63  ��6^   �� $ cbPhoneLines��$+ %SelectedItem.Config.KeepAliveInterval�$ TwoWay=�$ PropertyChanged=�63  �� 5�      $��1��6$   $��2��64   $	��sec��6A   $��23��6O   $
��Left=�6[   $��Center=�6v   $��40,1.5,0,1.5q�6�   $��27��6�   5�      5�      � 5�      
�������$��5��62   $��3��6?    5�      �� 5�      $	��297 �6/   �� 5�      $	��472 �6/   �� 5�      $
��209* �6/   .+�5�      �� -1   5        $��tcMedia��5�   %   $	��182��64   $��	10,10,0,0q�6A   $
��Left=�6T   $	��Top=�6o   $	��749��6�   $��2��6�   .@�5�      �� -2   5        $!��tiMicrophoneSpeakerSettings��5�   =   $��Audio devices��6&   .��5�   "   � .+�5�   &   �� -3   5        $��grpMicrophoneSettings��5�   /   $��Microphone settings��6L   $	��110��6i   $
��Left=�6v   $��9,6,0,0q�6�   $	��Top=�6�   $	��355��6�   $��2��6�   .��5�   *   �  5�   .   �� 5�   2   $��60 �6C   �� 5�   2   $	��214 �6C   �� 5�   2   $	��77* �6C   
 5�   .   �� 5�   2   $��6 �6@   �� 5�   2   $��30 �6@   �� 5�   2   $��25 �6@   �� 5�   2   $	��19* �6@   .+�5�   .   �� -4   5        $��lMicrophoneDevice��5�   4   $��Device:��6M   $��0��6_   $��2��6p   $��Right=�6}   $��Center=�6�   �� 5�   .   -5   5        $��cbMicrophoneDevices��5�   7   $��1��6�   $��2��6�   $��Center=�6�   $	��0,2q�6  ��6R   �� *MediaHandlers.Microphones+ 6�   �� *%#MediaHandlers.Microphone.DeviceInfo+$ OneWay=�6  �� 5�   .   -6   5        $��btnRefreshMicrophones��5�   5   $��Refresh��6R   $��1��6d   $��3��6t   $
��Left=�6�   $��Center=�6�   $��75��6�   $��	139,0,0,6q�6�   �� 5�   .   -7   5        $��lMicrophoneVolume��5�   4   $��Volume:��6M   $��0��6_   $��1��6o   $��Right=�6|   $��Center=�6�   �� 5�   .   -8   5        $��sMicrophoneVolume��5�   5    � Minimum$ 0Q�6�    � Maximum$ 1Q�6�    �� TickFrequency$	 0.1Q�6�    � SmallChange$	 0.1Q�6�    � LargeChange$	 0.2Q�6�   $��1��6�   $��1��6�   $��Center=�6�   $��0,2,6,2q�6   � Value 6N   �� *!MediaHandlers.Microphone.Volume+6  �� 5�   .   -9   5        $��chkbMicrophoneMute��5�   7   $
��Mute��6�   $��2��6�   $��1��6�   $��16��6�   $
��Left=�6�   $��Center=�6�   $	��2,7q�6�   $��59��6   6Q   �� * MediaHandlers.Microphone.Muted+6  � 5�   .   -:   5        $��pbMicrophoneLevel��5�   :   $ 0Q�6�   $	 100Q�6�   $��2��6�   $��1��6�   $
��75.5��6�   $��Center=�6�   $��	0,0,4,6.5q�6�    � Orientation$ Vertical=�6  $��3��6  $��Right=�6+  $��14��6G   6S   �� *MediaHandlers.MicrophoneLevel+$ OneWay=�6G  5�   +   5�   '   �� 5�   &   -;   5        $��grpSpeakerSettings��5�   /   $��Speaker settings��6I   $��369,6,-25,0q�6c   $	��110��6x   $
��Left=�6�   $	��Top=�6�   $	��355��6�   $��2��6�   .��5�   *   �  5�   .   �� 5�   2   $��60 �6C   �� 5�   2   $	��214 �6C   �� 5�   2   $	��77* �6C   
 5�   .   �� 5�   2   $��6 �6@   �� 5�   2   $��30 �6@   �� 5�   2   $��25 �6@   �� 5�   2   $	��19* �6@   .+�5�   .   �� -<   5        $��lSpeakerDevice��5�   4   $��Device:��6J   $��0��6\   $��2��6m   $��Right=�6z   $��Center=�6�   �� 5�   .   -=   5        $��cbSpeakerDevices��5�   7   $  �� IsSynchronizedWithCurrentItem$
  TrueY�6~   $��1��6�   $��2��6�   $��Center=�6  $	��0,2q�6"  ��6O   �� *MediaHandlers.Speakers+ 6�   �� *" MediaHandlers.Speaker.DeviceInfo+$ OneWay=�6/  �� 5�   .   ->   5        $��btnRefreshSpeakers��5�   5   $��Refresh��6O   $��1��6a   $��3��6q   $
��Left=�6�   $��Center=�6�   $��75��6�   $��	139,3,0,3q�6�   �� 5�   .   -?   5        $��lSpeakerVolume��5�   4   $��Volume:��6J   $��0��6\   $��1��6l   $��Right=�6y   $��Center=�6�   �� 5�   .   -@   5        $��sSpeakerVolume��5�   5   $ 0Q�6z   $ 1Q�6�   $	 0.1Q�6�   $	 0.1Q�6�   $	 0.2Q�6�   $��1��6�   $��1��6�   $��Center=�6�   $��0,2,6,2q�6   6K   �� *MediaHandlers.Speaker.Volume+6  �� 5�   .   -A   5        $��chkbSpeakerMute��5�   7   $
��Mute��6�   $��2��6�   $��1��6�   $��16��6�   $
��Left=�6�   $��Center=�6�   $	��2,7q�6�   $��59��6�    6N   �� *MediaHandlers.Speaker.Muted+6�   � 5�   .   -B   5        $��pbSpeakerLevel��5�   :   $ 0Q�6�   $	 100Q�6�   $��2��6�   $��1��6�   $
��78.5��6�   $��Center=�6�   $��	0,0,4,3.5q�6�   $ Vertical=�6�   $��3��6  $��Right=�6&  $��14��6B   6P   �� *MediaHandlers.SpeakerLevel+$ OneWay=�6B  5�   +   5�   '   5�   #   5�      �� 5�      -C   5        ! ��Name$! tiCameraSettings��5�   6   $��Camera��6&   .��5�   "   � .+�5�   &   �� -D   5        " ��Name$" grpCameraSettings��5�   /   $��Camera settings��6J   $	��107��6c   $
��Left=�6p   $��9,6,0,0q�6�   $	��Top=�6�   $	��395��6�   .��5�   *   �  5�   .   �� 5�   2   $��80 �6C   �� 5�   2   $	��214 �6C   �� 5�   2   $	��77* �6C   
 5�   .   �� 5�   2   $��6 �6@   �� 5�   2   $��25 �6@   �� 5�   2   $��25 �6@   �� 5�   2   $��25 �6@   �� 5�   2   $	��19* �6@   .+�5�   .   �� -E   5        # ��Name$# lCameraDevice��5�   4   $��Device:��6K   $��0��6]   $��1��6n   $��Right=�6{   $��Center=�6�   �� 5�   .   -F   5        $ ��Name$$ cbCameraDevices��5�   7   $��1��6�   $��1��6�   $��Center=�6�   $��0,0,6,0q�6�   ��6P   �� *MediaHandlers.Cameras+% �� SelectedIndex% 6~   �� *" MediaHandlers.WebCamera.DeviceID+$ OneWay=�6  �� 5�   .   -G   5        & ��Name$& btnRefreshCameras��5�   5   $��Refresh��6P   $��2��6b   $��1��6r   $
��Left=�6�   $��Center=�6�   $��75��6�   6�   �� 5�   .   -H   5        $# lCameraResolution��5�   4   $��Resolution:��6O   $��2��6e   $��0��6r   $��Right=�6�   $��Center=�6�   �� 5�   .   -I   5        $$ cbCameraResolutions��5�   7   $��1��61  $��2��6A  $��Center=�6N  $��0,0,92,0q�6i  ��6T   �� *&$MediaHandlers.WebCamera.Capabilities+# [  6�   �� *$"MediaHandlers.WebCamera.Resolution+# [ 6i  �� 5�   .   -J   5        $# lCameraFrameRate��5�   4   $��Frame rate:��6N   $��3��6d   $��0��6q   $��Right=�6�   $��Center=�6�   �� 5   .   -K   5        $$ cbCameraFrameRates��5   7   $��1��68  $��3��6H  $��Center=�6U  $��	0,0,159,0q�6p  ��6S   �� *MediaHandlers.FrameRates+# [  6�   �� **(MediaHandlers.WebCamera.DesiredFrameRate+# [ 6p  5  +   5  '   5  #   5     �� 5     $��Codecs��6&   .��5  "   � .+�5  &   �� -L   5        $" grpAudioCodecs��5  /   $��Audio codecs��6G   $��10,5,0,0q�6]   $��0��6o   $	��140��6   $	��Top=�6�   $
��Left=�6�   $	��355��6�   .��5	  *   � .+�5
  .   �� -M   5        ' ��Name$' lbAudioCodecs��5
  6   #��[ 6�   $��81��6�   $��6,6,10,0q�6�   $	��Top=�6�   ��6M   �� *Model.AudioCodecs+$ OneWay=���5  2   �� 5  6   .R�5  :   �� -N   5        $��11(�5  �   ��6C   �� *	CodecName+ 6a   �� *	Enabled+ 6   �� *PayloadType+6�   5  7   5  /   �� 5  .   -O   5        $& btnSelectAllAudioCodecs��5  5   $��
Select all��6V   $��0,92.12,90,0q�6k   $	��Top=�6�   $��Right=�6�   $��75��6�   �� 5  .   -P   5        $& btnDeselectAllAudioCodecs��5  5   $��Deselect all��6X   $��0,92.12,10,0q�6o   $	��Top=�6�   $��Right=�6�   $��75��6�   5  +   5  '   �� 5  &   -Q   5        $" grpVideoCodecs��5  /   $��Video codecs��6G   $	��Top=�6]   $��	369,6,0,0q�6u   $��0��6�   $	��139��6�   $
��Left=�6�   $	��303��6�   .��5  *   � .+�5  .   �� -R   5        $' lbVideoCodecs��5  6   #��[ 6�   $��81��6�   $
��Left=�6�   $��6,6,0,0q�6�   $	��Top=�6�   $	��173��6  ��6M   �� *Model.VideoCodecs+$ OneWay=���5  2   �� 5  6   .R�5  :   �� -S   5        $��11(�5  �   ��6C   �� *	CodecName+ 6a   �� *	Enabled+$ OneWay=� 6�   �� *PayloadType+6�   5  7   5  /   �� 5  .   -T   5        $& btnSelectAllVideoCodecs��5  5   $��
Select all��6V   $
��Left=�6l   $��	24,92,0,0q�6�   $��75��6�   $��22��6�   $	��Top=�6�   �� 5  .   -U   5        $& btnDeselectAllVideoCodecs��5  5   $��Deselect all��6X   $
��Left=�6o   $��
104,92,0,0q�6�   $	��Top=�6�   $��75��6�   6�   �� 5   .   $��Encoding Quality:��64   $
��Left=�6P   $��	184,0,0,0q�6k   $	��Top=�6~   �� 5!  .   $��
188,26,0,0q�6�   $��24��6�   $	��Top=�6�   $
��Left=�6�   $��99��6�   ��67   �� *VideoQualities+ 6^   �� *VideoEncoderQuality+6�   5"  +   5#  '   5%  #   5&     �� 5'     -V   5        $��
tiPlayback��5'  8   $��Playback��6&   .��5(  "   � 
 5)  &   �� 5*  *   $	��100 �68   �� 5+  *   $	��96* �68   .+�5-  &   �� -W   5        $��grpWavPlayback��5-  /   $��Wav Playback��6E   $��90��6[   $
��Left=�6g   $��9,6,0,0q�6�   $	��Top=�6�   $	��355��6�   .��5.  *   �  5/  .   �� 50  2   $��40 �6C   �� 51  2   $
��300* �6C   �� 52  2   $��55 �6C   
 54  .   �� 55  2   $��6 �6@   �� 56  2   $��25 �6@   �� 57  2   $��25 �6@   �� 58  2   $	��64* �6@   .+�5:  .   �� -X   5        $��lWavPlaybackFile��5:  4   $��File:��6L   $��1��6\   $��28��6i   $��Right=�6u   $��Center=�6�   �� 5;  .   -Y   5        $��tbWavPlaybackFile��5;  6   ( �� 
IsReadOnly( . {�.  $��Center=�6�   $��1��6�   $��1��6�   ��6O   �� *WavPlaybackFileName+$ OneWay=�6�   �� 5<  .   -Z   5        $��btnBrowseWavPlaybackFile��5<  5   $��Browse��6U   $��Center=�6f   $��1��6�   $��2��6�   $��2,0,2,2q�6�   6�   �� 5>  .   -[   5        $��btnPlayWavPlaybackFile��5>  5   $
��Play��6S   $��Right=�6�   $��Center=�6�   $��52��6  $��2��6  $��1��6)  $��	0,1,110,0q�69  {�6b   �� $ tbWavPlaybackFile��$
 Text�# [ 6L  �� 5?  .   -\   5        $��btnPauseWavPlaybackFile��5?  5   $��Pause��6T   $��Right=�6�   $��Center=�6�   $��52��6  $��2��6  $��1��6+  $��0,1,55,0q�6;  {�6d   �� $ tbWavPlaybackFile��$
 Text�# [ 6M  �� 5@  .   -]   5        $��btnStopWavPlaybackFile��5@  5   $
��Stop��6S   $��Right=�6�   $��Center=�6�   $��52��6  $��2��6  $��1��6)  $��0,1,0,0q�69  {�6b   �� $ tbWavPlaybackFile��$
 Text�# [ 6J  5A  +   5B  '   �� 5D  &   -^   5        $��grpMP3Playback��5D  /   $��MP3 Playback��6E   $��90��6[   $
��Left=�6g   $��	369,6,0,0q�6�   $	��Top=�6�   $	��355��6�   .��5E  *   �  5F  .   �� 5G  2   $��40 �6C   �� 5H  2   $
��300* �6C   �� 5I  2   $��55 �6C   
 5K  .   �� 5L  2   $��6 �6@   �� 5M  2   $��25 �6@   �� 5N  2   $��25 �6@   �� 5O  2   $	��64* �6@   .+�5Q  .   �� -_   5        $��lMP3PlaybackFile��5Q  4   $��File:��6L   $��1��6\   $��28��6i   $��Right=�6u   $��Center=�6�   �� 5R  .   -`   5        $��tbMP3PlaybackFile��5R  6   ( . {�.  $��Center=�6�   $��1��6�   $��1��6�   ��6O   �� *MP3PlaybackFileName+$ OneWay=�6�   �� 5S  .   -a   5        $��btnBrowseMP3PlaybackFile��5S  5   $��Browse��6U   $��Center=�6f   $��1��6�   $��2��6�   $��2,0,2,2q�6�   6�   �� 5U  .   -b   5        $��btnPlayMP3PlaybackFile��5U  5   $
��Play��6S   $��Right=�6�   $��Center=�6�   $��52��6  $��2��6  $��1��6)  $��	0,1,110,1q�69  {�6b   �� $ tbMP3PlaybackFile��$
 Text�# [ 6L  �� 5V  .   -c   5        $��btnPauseMP3PlaybackFile��5V  5   $��Pause��6T   $��Right=�6�   $��Center=�6�   $��52��6  $��2��6  $��1��6+  $��0,1,55,1q�6;  {�6d   �� $ tbMP3PlaybackFile��$
 Text�# [ 6M  �� 5W  .   -d   5        $��btnStopMP3PlaybackFile��5W  5   $
��Stop��6S   $��Right=�6�   $��Center=�6�   $��52��6  $��2��6  $��1��6)  $��0,1,0,1q�69  {�6b   �� $ tbMP3PlaybackFile��$
 Text�# [ 6J  5X  +   5Y  '   5Z  #   5[     �� 5\     -e   5        $��tiRecord��5\  6   $��Record��6&   .��5]  "   � .+�5^  &   �� -f   5        $��grpWavRecord��5^  /   $��
Wav Record��6C   $��90��6W   $	��9,6q�6c   $
��Left=�6p   $	��Top=�6�   $	��355��6�   .��5_  *   �  5`  .   �� 5a  2   $��40 �6C   �� 5b  2   $
��300* �6C   �� 5c  2   $��55 �6C   
 5e  .   �� 5f  2   $��6 �6@   �� 5g  2   $��25 �6@   �� 5h  2   $��25 �6@   �� 5i  2   $	��64* �6@   .+�5k  .   �� -g   5        $��lWavRecordFile��5k  4   $��File:��6J   $��1��6Z   $��28��6g   $��Right=�6s   $��Center=�6�   �� 5l  .   -h   5        $��tbWavRecordFile��5l  6   ( . {�.  $��Center=�6�   $��1��6�   $��1��6�   ��6M   �� *WavRecordFileName+$ OneWay=�6�   �� 5m  .   -i   5        $��btnBrowseWavRecordFile��5m  5   $��Browse��6S   $��Center=�6d   $��1��6   $��2��6�   $��2,0,2,2q�6�   6�   �� 5o  .   -j   5        $��btnRecordWavRecordFile��5o  5   $��Record��6S   $��Right=�6�   $��Center=�6�   $��52��6  $��2��6  $��1��6)  $��	0,1,110,0q�69  {�6d   �� $ tbWavRecordFile��$
 Text�# [ 6L  �� 5p  .   -k   5        $��btnPauseWavRecordFile��5p  5   $��Pause��6R   $��Right=�6�   $��Center=�6�   $��52��6  $��2��6  $��1��6'  $��0,1,55,0q�67  {�6b   �� $ tbWavRecordFile��$
 Text�# [ 6I  �� 5q  .   -l   5        $��btnStopWavRecordFile��5q  5   $
��Stop��6Q   $��Right=�6�   $��Center=�6�   $��52��6  $��2��6  $��1��6%  $��0,1,0,0q�65  {�6`   �� $ tbWavRecordFile��$
 Text�# [ 6G  5r  +   5s  '   5t  #   5u     �� 5v     $��	Ringtones��6&   .��5w  "   � .+�5x  &   �� -m   5        $��grpRingback��5x  /   $��Ringback file��6B   $��59��6Y   $
��Left=�6e   $��9,6,0,0q�6�   $	��Top=�6�   $	��355��6�   .��5y  *   �  5z  .   �� 5{  2   $��40 �6C   �� 5|  2   $
��300* �6C   �� 5}  2   $��55 �6C   
 5  .   �� 5�  2   $��6 �6@   �� 5�  2   $��25 �6@   �� 5�  2   $	��64* �6@   .+�5�  .   �� -n   5        $��lRingbackFile��5�  4   $��File:��6I   $��1��6Y   $��28��6f   $��Right=�6r   $��Center=�6�   �� 5�  .   -o   5        $��tbRingbackFile��5�  6   ( . {�.  $��Center=�6�   $��1��6�   $��1��6�   ��6L   �� *RingbackFileName+$ OneWay=�# [	 6�   �� 5�  .   -p   5        $��btnBrowseRingbackFile��5�  5   $��Browse��6R   $��Center=�6c   $��1��6~   $��2��6�   $��2,0,2,2q�6�   6�   5�  +   5�  '   �� 5�  &   -q   5        $��grpRingtone��5�  /   $��Ringtone file��6B   $��59��6Y   $
��Left=�6e   $��	369,6,0,0q�6�   $	��Top=�6�   $	��355��6�   .��5�  *   �  5�  .   �� 5�  2   $��40 �6C   �� 5�  2   $
��300* �6C   �� 5�  2   $��55 �6C   
 5�  .   �� 5�  2   $��6 �6@   �� 5�  2   $��25 �6@   �� 5�  2   $	��64* �6@   .+�5�  .   �� -r   5        $��lRingtonekFile��5�  4   $��File:��6J   $��1��6Z   $��28��6g   $��Right=�6s   $��Center=�6�   �� 5�  .   -s   5        $��tbRingtoneFile��5�  6   ( . {�.  $��Center=�6�   $��1��6�   $��1��6�   ��6L   �� *RingtoneFileName+$ OneWay=�# [	 6�   �� 5�  .   -t   5        $��btnBrowseRingtoneFile��5�  5   $��Browse��6R   $��Center=�6c   $��1��6~   $��2��6�   $��2,0,2,2q�6�   6�   5�  +   5�  '   5�  #   5�     �� 5�     -u   5        $��tiVoiceQuality��5�  =   $��Voice Quality��6&   .��5�  "   �  5�  &   �� 5�  *   $��15 �6;   �� 5�  *   $	��150 �6;   �� 5�  *   $	��130 �6;   �� 5�  *   $��90 �6;   �� 5�  *   $��50 �6;   �� 5�  *   $	��20* �6;   
 5�  &   �� 5�  *   $��6 �68   �� 5�  *   $��25 �68   �� 5�  *   $��25 �68   �� 5�  *   $��25 �68   �� 5�  *   $	��68* �68   .+�5�  &   �� -v   5        $��lEchoCancellation��5�  ,   $��Echo Cancellation:��6E   $��Right=�6b   $��1��6~   $��1��6�   $��Center=�6�   �� 5�  &   -w   5        $��chkbEchoCancellation��5�  /   $�� ��6K   $��16��6�   $
��Left=�6�   $��Center=�6�   $��1��6�   $��2��6�   $	��0,4q�6    6V   �� *64MediaHandlers.AudioEnhancer.AcousticEchoCancellation+6   �� 5�  &   -x   5        $��
lEchoDelay��5�  ,   $��Echo Delay:��6>   $��Right=�6T   $��3��6p   $��1��6�   $��Center=�6�   �� 5�  &   -y   5        $��tbEchoDelay��5�  .   $��4��6x   $��1��6�   $��Center=�6�   ��6A   �� *'%MediaHandlers.AudioEnhancer.EchoDelay+6�   �� 5�  &   -z   5        $
��lAGC��5�  ,   $��Auto Gain Control:��68   $��Right=�6U   $��1��6q   $��2��6�   $��Center=�6�   �� 5�  &   -{   5        $��chkbAGC��5�  /   $�� ��6>   $��2��6�   $��2��6�   $��16��6�   $
��Left=�6�   $��Center=�6�   $	��0,4q�6�    6I   �� *-+MediaHandlers.AudioEnhancer.AutoGainControl+6�   �� 5�  &   -|   5        $��lAGCMaxGain��5�  ,   $��	Max Gain:��6?   $��Right=�6S   $��3��6o   $��2��6   $��Center=�6�   �� 5�  &   -}   5        $��tbAGCMaxGain��5�  .   $��4��6w   $��2��6�   $��Center=�6�   ��6B   �� *%#MediaHandlers.AudioEnhancer.MaxGain+6�   �� 5�  &   -~   5        $��lNoiseReductionLevel��5�  ,   $��Noise Reduction Level:��6H   $��1��6i   $��3��6y   $��Right=�6�   $��Center=�6�   �� 5�  &   -   5        $��cbNoiseReductionLevel��5�  /   $��2��6�   $��3��6�   $
��Left=�6�   $��Center=�6  $	��120��6#  $	��0,2q�6/  ��6L   �� *$"MediaHandlers.NoiseReductionLevels+ 6�   �� *1/MediaHandlers.AudioEnhancer.NoiseReductionLevel+6/  5�  #   5�     5�     �� 5�     -�   5        $��grpLocalVideo��5�  #   $��Local video��68   $	��192��6M   $	��Top=�6Z   $��2��6r   $
��Left=�6�   .��5�     � 
 5�  "   �� 5�  &   $	��73* �64   �� 5�  &   $	��12* �64    5�  "   �� 5�  &   $	��96* �67   �� 5�  &   $	��94* �67   .+�5�  "     -�   5        $��localVideoViewer��5�  |   $	��180��67   $	��135��6C   $
��Left=�6P   $��4,7,0,0q�6k   $	��Top=�6�   $��2��6�   �� 5�  "   -�   5        $��btnStartVideo��5�  [   $��Start camera��6)   $
��Left=�6@   $	��Top=�6p   $��85��6�   $��1��6�   $��4,0,0,0q�6�   �� 5�  "   -�   5        $��btnStopVideo��5�  \   $��Stop camera��6)   $��Right=�6?   $	��Top=�6p   $��85��6�   $��1��6�   $��1��6�   5�     5�     �� 5�     -�   5        $��subtitle��5�  �   $��3��6"   $
��Left=�66   $��23��6Q   $��
10,193,0,0q�6]   $
 Wrap=�6q   $	��Top=�6�   $	��954��6�   ��6�   �� *
SubTitle+6�   5�     �� 5�     $��1��6   $��Phone Lines��6/   $
��Left=�6D   $��1��6_   $	��426��6l   $��0,0,0,5q�6x   .��5�     � 
 5�     �� 5�  "   $��8 �60   �� 5�  "   $��26 �60   �� 5�  "   $��26 �60   �� 5�  "   $	��47* �60    5�     �� 5�  "   $	��59* �63   �� 5�  "   $
��197* �63   �� 5�  "   $
��154* �63   .+�5�     �� -�   5        $��cbPhoneLines��5�  '   $
��Left=�6;   $��25��6�   $��Bottom=�6�   $��1��6
  $	��193��6  $��1��6&  ��6V   �� *Model.PhoneLines+# [   6�   �� *Model.SelectedLine+��5�  "   �� 5�  &   .R�5�  *   �� ��64   �� $ 
SIPAccount�# [  5�  '   5�     �� 5�     $��Line:��6$   $��1��64   $��Right=�6A   $��Bottom=�6]   $��0��6x   �� 5�     -�   5        $��btnAddPhoneLine��5�  %   $��Add SIP account��6<   $
��Left=�6V   $��Center=�6q   $��96��6�   $��2��6�   $��1��6�   �� 5�     -�   5        $��btnModifyPhoneLine��5�  %   $��Modify��6?   $
��Left=�6P   $��99,0,0,0q�6k   $��Center=�6}   $��53��6�   $��2��6�   $��1��6�   6�   �� 5�     -�   5        $��btnRemovePhoneLine��5�  %   $��Remove��6?   $
��Left=�6P   $��99,0,0,0q�6k   $��Center=�6}   $��53��6�   $��2��6�   $��2��6�   �� 5�     $��Status:��6$   $��2��66   $��Right=�6C   $��Center=�6_   $��0��6z   $	��0,1q�6�   �� 5�     -�   5        $��tbPhoneLineStatus��5�  &   $��2��6�   $��1��6�   ( . $
��Left=�6�   $��Center=�6�   $	��193��6�   ��6?   �� $ cbPhoneLines��$ SelectedItem.RegState�$ OneWay=�6�   �� 5�     -�   5        $��btnMessageSummary��5�  %   $��2��6P  $��2��6`  $
��Left=�6m  $��Center=�6�  $��96��6�  $	��0,3q�6�  ��6>   �� $ cbPhoneLines��$ SelectedItem�$ OneWay=�# [ {�6�   �� $ cbPhoneLines��$ SelectedItem�$ OneWay=�# [ 6�  �� 5�     -�   5        $��btnRegister��5�  %   $��Register��68   $��23��6K   $
��Left=�6W   $	��Top=�6r   $��75��6�   $��3��6�   $��1��6�   $��38,0,0,0q�6�   �� 5�     -�   5        $��btnUnRegister��5�  %   $��
Unregister��6:   $��23��6O   $
��Left=�6[   $	��Top=�6v   $��75��6�   $��3��6�   $��1��6�   $��	118,0,0,0q�6�   5�     5�     �� 5�     $��2��6   $��Network��6/   $
��Left=�6@   $��1��6[   $	��196��6h   $��0,0,0,5q�6t   .��5�     � 
 5�     �� 5�  "   $��10 �60   �� 5�  "   $��26 �60   �� 5�  "   $��26 �60   �� 5�  "   $��26 �60   �� 5�  "   $��9* �60    5�     �� 5�  "   $	��55* �63   �� 5�  "   $
��129* �63   .+�5�     �� -�   5        $��Discover NAT��5�  %   $
��Left=�6<   $	��Top=�6W   $��82��6o   $��3��6�   $��14,0,0,0q�6�   $��2��6�   $��22��6�   �� 5�     -�   5        $��Apply��5�  %   $��Right=�65   $	��Top=�6Q   $��82��6i   $��3��6�   $��1��6�   $��22��6�   �� 5�     $��	Local IP:��6$   $��Right=�68   $��1��6T   $	��Top=�6a   �� 5�     $��1��6'   $��1��6�   $
��Left=�6�   $��Center=�6�   $	��0,2q�6  $	��129��6#  ��67   �� *Model.LocalIPAddressList+{�6h   �� $ chkbUseSelectedIP��$ 	IsChecked� 6�   �� *Model.LocalIP+6#  �� 5      -�   5        $��chkbUseSelectedIP��5   '   $��Use selected IP��6@   $��1��6y   $��Right=�6�   $��2��6�   $��Center=�6�   $	��0,5q�6�    6Z   �� *
UseFixIP+6�   5     5     5     5     �� 5     $	��Log��6   $��20��6#   $	��Top=�6/    5     ) �� 
TargetType  LogViewerStyle* �� Property+ �� Value, K� IsItemsHost- �� DataType*   $OzekiDemoSoftphoneWPF.Model.LogEntry. � IsSharedSizeScope/ z� SharedSizeGroup��%   &	       (�� �     5  #   *, +)�� 5     ") ��6   .�5     �� * � ��+ 5	     �� 5
  "   .R�5  &   �� ��. .��5  *   �� 5  '   5  #   5     �� 5     * � ��+ 5     �� 5  "   .R�5  &   $� , . 6=   5  #   5     5     �� 5     "-  6#   .R�5     � . .  5     �� 5  "   $/ Index��63   $
��Auto �6K   �� 5  "   $
/ Date��63   $
��Auto �6J   �� 5!  "   .+�5#     �� $��0��6?   $
��Bold"�5$     $��0,0,2,0q�6*   ��5#  (   �� *Index+5$  *   �� 5%     $��1��6B   $
��Bold"�5&     $��5,0,5,0q�6*   ��5%  (   �� *
DateTime+5&  *   �� 5)     $��2��6A   $
��Wrap=�5*     ��5)  (   �� *	Message+5*     5+     5,     5-     .��5.     ]� .+�5/     �� $	��Top=�50     ��5/      �� *Model.LogEntries.Count+0 �� StringFormat$0 	{0} Items��50     �� 52     #��[ 6L   ��6#   �� *Model.LogEntries+��53     �� 54     .R�55  "   �� ��. .��56  &   �� 57  #   58     ��5:     �� 5;     .R�5<  "   $� , . 69   5=     5?     5@     5A     5B     5C     5F     