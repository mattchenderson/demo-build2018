# demo-build2018

Herein can be found all the resources being used to make THR2004 and THR3302 happen.

**setup.ps1**: resets the demo entirely and does some machine setup stuff (such as opening relevant apps and browser tabs)
**provision.ps1**: deploys all resources
**teardown.ps1**: deletes all resources, including any AAD applications which are tracked by App Service Authentication / Authorization

## THR2004 script

### App Service Authentication / Authorization
1. Start with the deployed Linux app, and show it working.
2. Add AAD authentication using the Express mode.
3. Show the automatic redirect.
4. Show the /.auth/login endpoint (and describe bearer usage).
5. Show /.auth/me and discuss the x-ms-client-* and x-ms-token-* headers.
6. Discuss on-behalf-of scenarios.
7. Call the site as an API in PostMan, with and without the token.
8. Steal a token from the Azure portal and show it failing.
9. Show diagnostic logs to determine why it's failing.

### Managed Service Identity
1. Start with the deployed function app.
2. Add MSI to the function app.
3. Navigate to Key Vault and explain access policies.
4. Add an access policy for the function app with permission to get secrets. Emphasize the save issue.
5. Navigate back to the app and show the REST-based function. Explain how MSI works
6. Show the function working.
7. Navigate to the SDK-based function. Explain the benefits of the AppAuthentication library.
8. Show the function working.

## THR3302 script
1. Do the Functions "Hello, world!" with HttpTrigger.
2. Give a brief discussion of bindings (optionally doing the BlobTrigger demo).
3. Show the creation of the ProfilePhoto template (with discussion as you go) (undetermined if installation of extension should be included).
4. Show what the login registration actually did.
5. Show getting your profile photo.
6. Show Graph Explorer as a way of trying out different APIS you can leverage this with.
7. ??? (different binding, deciding which one - OneDrive?)
8. Demonstrate the ?prompt=consent approach to updating permissions.
9. Discuss webhooks and how they work.
10. Create the Graph webhook scenario for Outlook messages and send one to yourself.