#if defined(__has_include) && __has_include("UnityAppController.h")
#import "UnityAppController.h"
#endif
#import <Foundation/Foundation.h>
#import <MadexConsentManager/MadexConsentManager-Swift.h>
#import "MadexConsentDelegate.h"

UIViewController *MadexConsentRootViewController(void) {
#if defined(__has_include) && __has_include("UnityAppController.h")
    return ((UnityAppController *)[UIApplication sharedApplication].delegate).rootViewController;
#else
    return NULL;
#endif
}

void MadexLoadConsent(void) {
    [ConsentManager loadManager];
}

void MadexShowConsent(void) {
    [ConsentManager showConsentWindow:MadexConsentRootViewController()];
}

BOOL MadexHasConsent(void) {
    return [ConsentManager hasConsent];
}

void MadexConsentEnableDebug(BOOL isDebug){
    [ConsentManager enableLog:isDebug];
}

void MadexRegisterCustomConsentVendor(const char *appName, const char *policyUrl, const char *bundle, BOOL isGdpr){
    [ConsentManager registerCustomVendor:^(ConsentBuilder* builder) {
        (void)[builder appendName:[NSString stringWithUTF8String:appName]];
        (void)[builder appendPolicyURL:[NSString stringWithUTF8String:policyUrl]];
        (void)[builder appendBundle:[NSString stringWithUTF8String:bundle]];
        (void)[builder appendGDPR:isGdpr];
    }];
}

static MadexConsentDelegate *ConsentDelegateInstance;
void MadexSetConsentDelegate(
                                  ConsentCallbacks onConsentManagerLoaded,
                                  ConsentFailCallbacks onConsentManagerLoadFailed,
                                  ConsentCallbacks onConsentWindowShown,
                                  ConsentFailCallbacks onConsentManagerShownFailed,
                                  ConsenClosedCallbacks onConsentWindowClosed
                                  ) {
    
    ConsentDelegateInstance = [MadexConsentDelegate new];
    
    ConsentDelegateInstance.onConsentManagerLoadedCallback = onConsentManagerLoaded;
    ConsentDelegateInstance.onConsentManagerLoadFailedCallback = onConsentManagerLoadFailed;
    ConsentDelegateInstance.onConsentWindowShownCallback = onConsentWindowShown;
    ConsentDelegateInstance.onConsentManagerShownFailedCallback = onConsentManagerShownFailed;
    ConsentDelegateInstance.onConsentWindowClosedCallback = onConsentWindowClosed;
    
    
    [ConsentManager setDelegate:ConsentDelegateInstance];
}
