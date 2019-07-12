# mono1app
What is your test project

 

Summary: develop a minimalistic application of your choice by following technologies and concepts mentioned above and requirements defined below.

 

Requirements

·         Create a database with following elements

·         VehicleMake (Id,Name,Abrv) e.g. BMW,Ford,Volkswagen,

·         VehicleModel (Id,MakeId,Name,Abrv) e.g. 128,325,X5 (BWM), 

·         Create the solution (back-end) with following projects and elements

·         Project.Service

·         EF models for above database tables

·         VehicleService class - CRUD for Make and Model (Sorting, Filtering & Paging)

·         Project.MVC 

·         Make administration view (CRUD with Sorting, Filtering & Paging)

·         Model administration view (CRUD with Sorting, Filtering & Paging)

·         Filtering by Make


Implementation details 

·         all classes should be abstracted (have interfaces)

·         Mapping should be done by using AutoMapper (http://automapper.org/)

·         EF 6, Core or above with Code First approach (EF Power Tools can be used) should be used  

·         MVC project

·         return view models rather than EF database models

·         return proper Http status codes


Candidate should open a dedicated GitHub repository for the purpose of test project and occasionally report for code review.

 

Note: Try to use agile approach while building project, our suggestion is to build services with EF database models for above elements and report for first code review, then MVC project for the same part of the application following with report for second code review.

 

Regards
