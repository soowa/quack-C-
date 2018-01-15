Feature: Google Search

  Scenario Outline: Doing a google calculator search
    Given I opened google
    When I search for <query>
    When I hit enter
    Then The answer <answer> appears in the calculator

    Examples:
      |  query  | answer |
      |  1+1    |    2   |
      |  22+30  |   52   |
      |  90+312 |  402   |

  Scenario Outline: Doing a google search
    Given I opened google
    When I search for <query>
    When I hit enter
    Then The query <query> appears in the url

    Examples:
      |  query  |
      |  one    |
      |  two    |
      |  three  |