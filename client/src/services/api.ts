import axios from 'axios';

type Tasks = {
    id: number;
    taskName: string;
    description: string;
    startDate: Date,
    endDate: Date,
    finished: boolean
};

export async function getTasks() {
    try {
        const { data, status } = await axios.get<Array<Tasks>>(
            'https://localhost:7031/Tasks',
            {
                headers: {
                    Accept: 'application/json',
                },
            },
        );

        console.log(JSON.stringify(data, null, 4));

        console.log('response status is: ', status);

        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log('error message: ', error.message);
            return error.message;
        } else {
            console.log('unexpected error: ', error);
            return 'An unexpected error occurred';
        }
    }
}
