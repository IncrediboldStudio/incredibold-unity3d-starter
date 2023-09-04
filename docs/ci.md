# CI/CD

## Getting Started

This template uses [Github Actions](https://docs.github.com/en/actions) to upload builds for Windows x64 Standalone and WebGL. The WebGL build then gets deployed on [Netlify](https://www.netlify.com/). This pipeline uses [GameCI](https://game.ci/) to build the Unity project, so don't hesitate to visit their website if you want more detailed documentation.

### Workflows

#### Build & Deploy
The build workflow will run automatically on pull requests made on the `main` branch. It will build a Windows x64 and WebGL version of the project and save the completed builds as artifacts. The default artifact retention period on Github is 90 days, but you can update it by following these [instructions](https://docs.github.com/en/organizations/managing-organization-settings/configuring-the-retention-period-for-github-actions-artifacts-and-logs-in-your-organization). The WebGL version can also be deployed and hosted on Netlify.

#### Cleanup
This job runs every day at 1:00 am UTC and will delete every artifacts currently in the project

## Setup
To get the CI/CD pipeline up and running, you must have a [Unity ID](https://id.unity.com), as the Unity build job require an activated Unity license to work properly. Also, an optional step is to create a site on [Netlify](https://www.netlify.com/) to deploy the WebGL build. For more information on how to create secrets for your project, visit the official [Github documentation](https://docs.github.com/en/actions/security-guides/encrypted-secrets).

### Unity Activation
This workflow only needs to be run manually once, as you need to activate a Unity license for the build workflow. For more information on how to use this workflow, visit the [GameCI documentation](https://game.ci/docs/github/activation#converting-into-a-license).

Create the following secrets:
- `UNITY_EMAIL` The email you used to login to your Unity ID
- `UNITY_PASSWORD` The password you used to login to your Unity ID
- `UNITY_EMAIL` The content of the `.ulf` license file you generated

### Netlify Deployment
To add a new site on Netlify, login to your [Netlify account](https://app.netlify.com/), then follow [these instructions](https://docs.netlify.com/welcome/add-new-site/#deploy-local-files). Once this is done, you will have to generate a personal access token [here](https://docs.netlify.com/cli/get-started/#obtain-a-token-in-the-netlify-ui). **Be sure to save your access token, as it won't be accessible once it has been generated**.

Create the following secrets:
- `NETLIFY_AUTH_TOKEN` Your personal access token 
- `NETLIFY_SITE_ID` Your site ID in the `Site configuration > Site details` tab in your Netlify site dashboard