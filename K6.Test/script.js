import http from 'k6/http';
import { sleep, check } from 'k6';

const url = "https://localhost:7268/api/Order"
let body =  {
              cpf: "987.231.887-40",
              productIds: [1,2,3,4]
            }

export const options = {
  vus: 60,
  duration: '60s',
};

export default function () {
  //Get
  //const res = http.get('https://test.k6.io');

  //Post
  const res = http.post(url, JSON.stringify(body), {
    headers: { 'Content-Type': 'application/json' }
  })

  check(res, {
    'is status 200': (r) => r.status === 200,
  });

  sleep(1); // time in seconds
}
