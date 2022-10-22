import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import { fetchSuggs } from "./MapApi";

const initialState = {
    pointFrom: null,
    pointTo: null,
    isUserWantGetRoute: false,
    inputSuggestions: [],
    fetchingSuggestionsStatus: 'idle'
}

export const fetchSuggestions = createAsyncThunk(
    'map/fetchSuggestions',
    async(input) => {
        const response = await fetchSuggs(input);
        return response.data;
    }
)

const MapSlice = createSlice({
    name: 'map',
    initialState,
    reducers:{
        setPointFrom : (state, action) => {
            state.pointFrom = action.payload
        },
        clearSuggestions: (state) => {
            console.log("clearing")
            state.inputSuggestions = []
        }
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchSuggestions.pending, (state) =>{
                state.fetchingSuggestionsStatus = 'loading'
            })
            .addCase(fetchSuggestions.fulfilled, (state, action) => {
                state.fetchingSuggestionsStatus = 'idle'
                state.inputSuggestions = action.payload.hits
            })
    }
})

export const { setPointFrom, clearSuggestions } = MapSlice.actions

export const selectInputSuggestions = (state) => state.map.inputSuggestions;

export default MapSlice.reducer;