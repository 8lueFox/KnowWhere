export function fetchSuggs(input){
    return new Promise((resolve) => 
        setTimeout(() => resolve({data: [{city:'Biała Podlaska', country: 'Poland'}, {city:'Omagh', country: 'Nothern Ireland'}, {city:'Barcelona', country:'Spain'}]}), 500)
    )
}