# Delete call recordings for a phone number
This application is an implementation to show how you could use Twilio's helper libraries to quickly discover calls for a given filter criteria and then retrieve and optionally delete the recordings for them calls

## Setup
Firstly retreive your Account SID and Auth Code from the twilio console and set the `TWILIO_ACCOUNT_SID` and `TWILIO_AUTH_TOKEN` environement variables, for details see how to [Store Your Twilio Credentials Securely](https://www.twilio.com/docs/usage/secure-credentials).

## Operation
This application has 2 variables that you can set
1. `fromNumber` this is the number that you are expecting the calls you are querying to be from using E.164 format (+44XXXXXXXXXX).
2. `shouldActuallyDelete` use this variable if you would like to do a dry run, in this instance recordings will not be deleted.

## Warning
This code has been written for proof of concept purposes. Please fully test this code before running in your production environment