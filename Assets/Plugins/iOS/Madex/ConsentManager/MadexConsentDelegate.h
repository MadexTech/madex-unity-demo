#import <Foundation/Foundation.h>
#import <MadexConsentManager/MadexConsentManager-Swift.h>

typedef void (*ConsentCallbacks) (void);
typedef void (*ConsentFailCallbacks) (const char *);
typedef void (*ConsenClosedCallbacks) (BOOL);

@interface MadexConsentDelegate : NSObject <ConsentDelegate>

@property (assign, nonatomic) ConsentCallbacks onConsentManagerLoadedCallback;
@property (assign, nonatomic) ConsentFailCallbacks onConsentManagerLoadFailedCallback;
@property (assign, nonatomic) ConsentCallbacks onConsentWindowShownCallback;
@property (assign, nonatomic) ConsentFailCallbacks onConsentManagerShownFailedCallback;
@property (assign, nonatomic) ConsenClosedCallbacks onConsentWindowClosedCallback;

@end
