import http from 'k6/http';
import { sleep } from 'k6';
export const options = {
    stages: [
        { duration: '1m', target: 10 }, // ramp-up
        { duration: '2m', target: 10 }, // stay at
        { duration: '1m', target: 0 },  // ramp-down
    ],
    thresholds: {
        http_req_duration: ['p(95)<200'], // 95% of requests must complete below 300ms
        http_req_failed: ['rate<0.01'], // Error rate should be less than 1%
    },
};

export default function () {
    http.get('http://localhost:30007/pi?iterations=5000000');
    sleep(1);
}