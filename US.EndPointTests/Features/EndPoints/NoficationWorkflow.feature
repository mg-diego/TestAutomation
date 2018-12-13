Feature: NoficationWorkflow

@After_Scenario_StopRabbitQueue
Scenario: 7 Weeks - 3 Days - Red result and unseen
	Given Barcode id randomly generated
	Given Clean up Notification Workflow
	Given Rabbit queue is started
	Given a successful login
	Given request to register barcode
	Given request to register barcode with code '444' to push notifications
	Given App token is generated for 'ExportClient' client
	Given request to register result with '4000' as value
	When Wait EpisodeNumberUpdated event rabbit message
	When request to release results for barcode
	Then request to rabbit message for 3 days notification message
	#Then request to rabbit message to not expect a 2 weeks notification message
	Then request to rabbit message for 7 weeks notification message
	And request to rabbit message for fully notified message
	

@After_Scenario_StopRabbitQueue
Scenario: 3 Days - Unseen yellow result
	Given Barcode id randomly generated
	Given Clean up Notification Workflow
	Given Rabbit queue is started
	Given a successful login
	Given request to register barcode
	Given request to register barcode with code '444' to push notifications
	When Wait EpisodeNumberUpdated event rabbit message
	Given App token is generated for 'ExportClient' client
	Given request to register result with '400' as value
	When request to release results for barcode
	Then request to rabbit message for 3 days notification message
	#Then request to rabbit message to not expect a 2 weeks notification message
	#Then request to rabbit message to not expect a 7 weeks notification message
	#And request to rabbit message for fully notified message

@After_Scenario_StopRabbitQueue
Scenario: 3 Days - Yellow result and seen it before 3 days
	Given Barcode id randomly generated
	Given Clean up Notification Workflow
	Given Rabbit queue is started
	Given a successful login
	Given request to register barcode
	Given request to register barcode with code '444' to push notifications
	Given App token is generated for 'ExportClient' client
	When Wait EpisodeNumberUpdated event rabbit message	
	Given request to register result with '400' as value
	When request to release results for barcode
	When Wait for '180' seconds
	When request to get results from barcode 'random'
	Then request to rabbit message for 3 days notification message
	#Then request to rabbit message to not expect a 2 weeks notification message
	#Then request to rabbit message to not expect a 7 weeks notification message
	#And request to rabbit message for fully notified message

@After_Scenario_StopRabbitQueue
Scenario: 3 Days - Yellow result and seen it after 3 days
	Given Barcode id randomly generated
	Given Clean up Notification Workflow
	Given Rabbit queue is started
	Given a successful login
	Given request to register barcode
	Given request to register barcode with code '444' to push notifications
	Given App token is generated for 'ExportClient' client
	Given request to register result with '400' as value
	When Wait EpisodeNumberUpdated event rabbit message
	When request to release results for barcode
	Then request to rabbit message for 3 days notification message
	When request to get results from barcode 'random'
	Then request to rabbit message for 3 days notification message
	#Then request to rabbit message to not expect a 2 weeks notification message
	#Then request to rabbit message to not expect a 7 weeks notification message
	#And request to rabbit message for fully notified message


@After_Scenario_StopRabbitQueue
Scenario: 3 Days - Unseen green result
	Given Barcode id randomly generated
	Given Clean up Notification Workflow
	Given Rabbit queue is started
	Given a successful login
	Given request to register barcode
	Given request to register barcode with code '444' to push notifications
	When Wait EpisodeNumberUpdated event rabbit message
	Given App token is generated for 'ExportClient' client
	Given request to register result with '40' as value
	When request to release results for barcode 
	Then request to rabbit message for 3 days notification message
	#Then request to rabbit message to not expect a 2 weeks notification message
	#Then request to rabbit message to not expect a 7 weeks notification message
	#And request to rabbit message for fully notified message


@After_Scenario_StopRabbitQueue
Scenario: 2 weeks - Register a barcode without result
	Given Barcode id randomly generated
	Given Clean up Notification Workflow
	Given Rabbit queue is started
	Given a successful login
	Given request to register barcode
	Given request to register barcode with code '444' to push notifications
	When Wait EpisodeNumberUpdated event rabbit message
	#Then request to rabbit message to not expect a 3 days notification message
	Then request to rabbit message for 2 weeks notification message
	#Then request to rabbit message to not expect a 7 weeks notification message
	#And request to rabbit message for fully notified message


@After_Scenario_StopRabbitQueue
Scenario: No Notification - Green result and seen it before 3 days
	Given Barcode id randomly generated
	Given Clean up Notification Workflow
	Given Rabbit queue is started
	Given a successful login
	Given request to register barcode
	Given request to register barcode with code '444' to push notifications
	When Wait EpisodeNumberUpdated event rabbit message
	Given App token is generated for 'ExportClient' client
	Given request to register result with '40' as value	
	When request to get results from barcode 'random'
	Then The status code is '200'
	Then request to rabbit message to not expect a 3 days notification message
	Then request to rabbit message to not expect a 2 weeks notification message
	Then request to rabbit message to not expect a 7 weeks notification message
	#And request to rabbit message for fully notified message



@After_Scenario_StopRabbitQueue
Scenario: 7 weeks - 3 Days - Red result and seen it before 3 days
	Given Barcode id randomly generated
	Given Clean up Notification Workflow
	Given Rabbit queue is started
	Given a successful login
	Given request to register barcode
	Given request to register barcode with code '444' to push notifications
	Given App token is generated for 'ExportClient' client
	Given request to register result with '4000' as value
	When Wait EpisodeNumberUpdated event rabbit message
	When request to release results for barcode
	When request to get results from barcode 'random'
	Then request to rabbit message for 3 days notification message
	#Then request to rabbit message to not expect a 2 weeks notification message
	Then request to rabbit message for 7 weeks notification message
	#And request to rabbit message for fully notified message

@After_Scenario_StopRabbitQueue
Scenario: 7 Weeks - 3 Days - Red result and seen it after 3 days
	Given Barcode id randomly generated
	Given Clean up Notification Workflow
	Given Rabbit queue is started
	Given a successful login
	Given request to register barcode
	Given request to register barcode with code '444' to push notifications
	Given App token is generated for 'ExportClient' client
	Given request to register result with '4000' as value
	When Wait EpisodeNumberUpdated event rabbit message
	When request to release results for barcode
	Then request to rabbit message for 3 days notification message
	When request to get results from barcode 'random'
	Then request to rabbit message for 3 days notification message
	#Then request to rabbit message to not expect a 2 weeks notification message
	Then request to rabbit message for 7 weeks notification message
	#And request to rabbit message for fully notified message



@After_Scenario_StopRabbitQueue
Scenario: No Notification - Green result and seen it after 3 days
	Given Barcode id randomly generated
	Given Clean up Notification Workflow
	Given Rabbit queue is started
	Given a successful login
	Given request to register barcode
	Given request to register barcode with code '444' to push notifications
	Given App token is generated for 'ExportClient' client
	Given request to register result with '40' as value
	When Wait EpisodeNumberUpdated event rabbit message
	When request to release results for barcode
	Then request to rabbit message for 3 days notification message
	When request to get results from barcode 'random'
	Then request to rabbit message to not expect a 3 days notification message
	Then request to rabbit message to not expect a 2 weeks notification message
	Then request to rabbit message to not expect a 7 weeks notification message
	#And request to rabbit message for fully notified message

Scenario:  dummy
	Then DB for Push notifications does not contain an entry
