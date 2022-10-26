import axios from "axios"

export async function fetchSuggs(input){
    const request = { Query: input}
    const resp = await axios.post('http://localhost:9003/api/Geolocation/GetGeocoding', request)
    return resp;
}