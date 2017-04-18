# Nudnik--Alladin

## Steps for successful release of Oneg Run

### Unity

* File -> Build Settings -> Select Platform (IOS/Android)  -> Run in XCode as - Release -> Build

Build Phases -> Create New Script (for fabric) ->
Add the following script
./Fabric.framework/run 28e998f290bfbd1a2d1b585f2bedb6e04281bede 0a51f7334371f32f36820527f559a3c97a6ff5771759c8a44bb2db1664a42fab

#### Build Phases

Link Binary With Libraries:
- AddressBook.framework
- AssetsLibrary.framework
- CoreData.framework
- CoreLocation.framework
- CoreMotion.framework
- CoreTelephony.framework
- CoreText.framework
- Foundation.framework
- MediaPlayer.framework
- QuartzCore.framework
- SafariServices
- Security.framework
- SystemConfiguration.framework
- libc++.dylib
- libz.dylib
For more info check google play games ios:
https://developers.google.com/games/services/ios/quickstart


Add in in project fabric frameworks:
- Fabric.framework
- Crashlytics.framework

Run project -> cmd + B
Open Fabric app -> Select project

XCode -> Project -> Archive -> Distribute

For any questions email me at: sebastian@alttab.co
