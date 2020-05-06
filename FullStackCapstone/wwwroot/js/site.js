// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const allEditButtons = document.querySelectorAll(".editButton");

allEditButtons.forEach(eb => {
    eb.addEventListener("click", async e => {

        e.preventDefault();

     //make fetch request to url and then put it into the input values 

        const [d, id] = e.target.id.split("--");

        const response = await fetch(`/Opportunities/Edit/${id}`);

       
        const data = await response.json();  

        document.getElementById("edit-id").value = data.id
        document.getElementById("edit-title").value = data.title 
        document.getElementById("edit-description").value = data.description 
        document.getElementById("edit-applicationLink").value = data.applicationLink 
        document.getElementById("edit-startDate").value = data.startDate
        document.getElementById("edit-endDate").value = data.endDate
        document.getElementById("edit-ageRange").value = data.ageRange
        document.getElementById("edit-subjectId").value = data.subjectId
        document.getElementById("edit-programId").value = data.programTypeId
        document.getElementById("edit-applicationDeadline").value = data.applicationDeadline


            

    
    })
})