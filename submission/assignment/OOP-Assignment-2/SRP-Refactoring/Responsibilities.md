 ## Before Refactoring : Responsibilities of classes that violate the SRP

1) WardBoard:
        # Responsibilities:
                 - assigning patients to beds
                 - calculate patirent's acuity score
                 - build nurse handoff notes
                 - manage pager's alerts
                 - export bed occupancy data to CSV


        # why having them together is a problem ?
          - this class have multiple reasons to change , so it violates the SRP .
          for example :
                 - if the hospital wants to change the way of assigning patients to beds , we need to change this class
                 - if the hospital wants to chanage the csv export format , we need to change this class
                 - if doctors wants to change the way of calculating acuity score , we need to change this class
                 - if doctors wants to change the way of building handoff notes , we need to change this class
                 - if nurses needs to cahnge the handoff notes fomat , we need to change this class

2) CheckoutBasket:
        # Responsibilities:
                 - manage the items in the basket
                 - manage coupons
                 - calculate order price
                 - manage the payment process
                 - manage gift wrap and message options

        # why having them together is a problem ?
          - this class have multiple reasons to change , so it violates the SRP .
          for example :
                 - if the store wants to change the way of managing items in the basket , we need to change this class
                 - if the store wants to change the way of managing coupons , we need to change this class
                 - if the store wants to change the way of calculating order price , we need to change this class
                 - if the store wants to change the way of managing payment process , we need to change this class
                 - if the store wants to change the way of managing gift wrap and message options , we need to change this class

3) SupportTicket:
        # Responsibilities:
                 - store customer support tickets
                 - detect ticket priority depending on the content
                 - detect deadlines for tickets depending on priority
                 - draft public response for tickets
                 - manage internal escalation blurb

        # why having them together is a problem ?
          - this class have multiple reasons to change , so it violates the SRP .
          for example :
                 - if we need to change the way of storing customer support tickets , we need to change this class
                 - if we need to change the way of detecting ticket priority , we need to change this class
                 - if we need to change the way of detecting deadlines for tickets , we need to change this class
                 - if we need to change the format of drafting public response for tickets , we need to change this class
                 - if we need to change the format of internal escalation blurb , we need to change this class

4) LoanDesk:
        # Responsibilities:
                 - calculate loan eligibility depent on risk score
                 - mange required documents for loan application
                 - print loan decision letter
                 - generate loan application

        # why having them together is a problem ?
          - this class have multiple reasons to change , so it violates the SRP .
          for example :
                 - if we need to change the way of calculating loan eligibility , we need to change this class
                 - if we need to change the required documents for loan application , we need to change this class
                 - if we need to change the format of printing loan decision letter , we need to change this class
                 - if we need to change the way of generating loan application , we need to change this class

5) CourseEnrollmentDesk:
        # Responsibilities:
                 - manage course enrollment for students
                 - manage waitlist
                 - generate welcome packets
                 - invoice students for course fees

        # why having them together is a problem ?
          - this class have multiple reasons to change , so it violates the SRP .
          for example :
                 - if we need to change the way of managing course enrollment for students , we need to change this class
                 - if we need to change the way of managing waitlist , we need to change this class
                 - if we need to change the format of generating welcome packets , we need to change this class
                 - if we need to change the way of invoicing students for course fees , we need to change this class

6) KitchenTicket:
        # Responsibilities:
                 - store items , ingerdients and preparition minutes
                 - detect allergens based on specific ingredients
                 - estimate preparation time based on open station , preparation minutes allergy protocol delay
                 - render thermal printer kitchen and Expo Lane Hint

        # why having them together is a problem ?
          - this class have multiple reasons to change , so it violates the SRP .
          for example :
                 - if we need to change the way of storing items , ingerdients and preparition minutes , we need to change this class
                 - if we need to change the way of detecting allergens based on specific ingredients , we need to change this class
                 - if we need to change the way of estimating preparation time based on open station , preparation minutes allergy protocol delay , we need to change this class
                 - if we need to change the way of rendering thermal printer kitchen and Expo Lane Hint , we need to change this class


7) SubscriptionBilling:
        # Responsibilities:
                 - calculate pro-rated charges for subscription changes
                 - generate invoice numbers
                 - track payment failures
                 - generate dunning emails
                 - generate accounting ledger entries

                # why having them together is a problem ?
                 - this class have multiple reasons to change , so it violates the SRP .
                 for example :
                        - if we need to change the way of calculating pro-rated charges for subscription changes , we need to change this class
                        - if we need to change the way of generating invoice numbers , we need to change this class
                        - if we need to change the way of tracking payment failures , we need to change this class
                        - if we need to change the way of generating dunning emails , we need to change this class
                        - if we need to change the way of generating accounting ledger entries , we need to change this class


8) WarehousePickList:
        # Responsibilities:
                 - manage stock allocation
                 - manage walking order
                 - generate picker instructions
                 - generate xml batches

                 # why having them together is a problem ?
                  - this class have multiple reasons to change , so it violates the SRP .
                  for example :
                         - if we need to change the way of managing stock allocation , we need to change this class
                         - if we need to change the way of managing walking order , we need to change this class
                         - if we need to change the way of generating picker instructions , we need to change this class
                         - if we need to change the way of generating xml batches , we need to change this class

9) GradeBook :
        # Responsibilities:
                 - manage student grades (scores and averages)
                 - determine if hte student met the honors criteria based on average and scores
                 - generate transcripts
                 - generate grade data csv

                 # why having them together is a problem ?
                  - this class have multiple reasons to change , so it violates the SRP .
                  for example :
                         - if we need to change the way of managing student grades (scores and averages) , we need to change this class
                         - if we need to change the way of determining if hte student met the honors criteria based on average and scores ,
                                we need to change this class
                        - if we need to change the way of generating transcripts , we need to change this class
                         - if we need to change the way of generating grade data csv , we need to change this class


10) AppointmentDesk :
        # Responsibilities:
                 - manage booking appointments
                 - generate calendar file format for appointments
                 - send sms reminders for appointments

                 # why having them together is a problem ?
                  - this class have multiple reasons to change , so it violates the SRP .
                  for example :
                         - if we need to change the way of managing booking appointments , we need to change this class
                         - if we need to change the way of generating calendar file format for appointments , we need to change this class
                         - if we need to change the way of sending sms reminders for appointments , we need to change this class