## ConfigMan

ConfigMan is a configuration management server designed to have a central location to store configuration. Applications can be configured to load their configuration
on startup and be changed without requiring an application to be redeployed for a config change.

## Features
- Ability to define global deployment environments as well as global settings that all applications can inherit (e.g. you can set a log server for all applications)
- Create variables at the application level that are inherited by each environment
- .NET Configuration Provider
- Audit logs of changes

## Features I am thinking about
- Case Sensitive Config?
- Per Application Access (read/write/Whatever people want)?
- Secret storage?
- Variable version pinning?
- Live variables changes?
- Tracking of variable usages (may be .NET only)
- Host Based or Percentage Based Config. A certain percentage of clients can get a specific setting (this could be used for A/B testing)


## TODO
- Forgot Password
- Optomistic Concurrency
- Showing errors to user instead of console
- Internationalization

Environment Sets
- Delete Environment (apply to applications)
- Order Environments
- Duplicate Prevention (in progress)
- History (partially completed)

- Low Priority: Versioning (in progress)
- Low Priority: You should not be able to add an Environment Set variable if a child application is already using that name (or it can prompt you if that is the case)
- Low Priority: Duplicate Environment Set?

Applications
- Move logic from controller to service
- Can not remove/rename environment if from environment set
- Remove summary screen
- Order Environments
- Duplicate Prevention (in progress)
- History (partially completed)
- Applied Config 
- Regenerate Token

- Low Priority: Host Based or Percentage Based Config. A certain percentage of clients can get a specific setting (this could be used for A/B testing)
- Low Priority: Versioning (in progress)
- Low Priority: Detach from Environment Set
- Low Priority: Add custom environment in addition of what comes from environment set
- Low Priority: Copy Application
 
Users
- All of it

Settings
- All of it